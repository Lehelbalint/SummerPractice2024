
using BookStore.Data.Abstractions;
using BookStore.Data.MongoDB;
using BookStore.Domain;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyModel;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

internal class Program
{
	private static Assembly[] Assemblies;
	private static void Main(string[] args)
	{
		Assemblies = LoadApplicationDependecies();
		var builder = WebApplication.CreateBuilder(args);

		// Configure MongoDB settings
		var databaseSettings = new DatabaseConfiguration();
		builder.Configuration.Bind(nameof(DatabaseConfiguration), databaseSettings);
		builder.Services.AddSingleton<IDatabaseConfiguration>(databaseSettings);

		// Configure JWT settings
		builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

		// Register services
		builder.Services.AddFluentValidation(options =>
		{
			options.RegisterValidatorsFromAssemblies(Assemblies);
		});
		builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assemblies));
		builder.Services.Scan(scan => scan.FromAssemblies(Assemblies)
			.AddClasses(type => type.AssignableTo(typeof(IRepository<>))).AsImplementedInterfaces().WithScopedLifetime()
			.AddClasses(type => type.AssignableTo(typeof(IDatabase))).AsImplementedInterfaces().WithSingletonLifetime());

		builder.Services.AddSingleton<AuthenticationService>();

		// Add authentication
		var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
		builder.Services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.RequireHttpsMetadata = false;
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = builder.Configuration["Jwt:Issuer"],
				ValidAudience = builder.Configuration["Jwt:Audience"]
			};
		});

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		app.UseAuthentication();
		app.UseAuthorization();
		app.MapControllers();
		app.Run();
	}

	private static Assembly[] LoadApplicationDependecies()
	{
		var context = DependencyContext.Default;
		return context.RuntimeLibraries.SelectMany(library =>
			library.GetDefaultAssemblyNames(context))
			.Where(assembly => assembly.FullName.Contains("BookStore"))
			.Select(Assembly.Load).ToArray();
	}
}
