using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookStore.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IMongoCollection<User> _users;
		private readonly AuthenticationService _authService;

		public AuthController(IConfiguration config, AuthenticationService authService)
		{
			var client = new MongoClient("mongodb+srv://blehel:egkxj7c4@cluster0.37noliy.mongodb.net/");
			var database = client.GetDatabase("BookStore");
			_users = database.GetCollection<User>("Users");
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] User user)
		{
			var existingUser = await _users.Find(u => u.Username == user.Username).FirstOrDefaultAsync();
			if (existingUser != null)
			{
				return BadRequest("User already exists.");
			}

			user.Password = PasswordHasher.HashPassword(user.Password);
			await _users.InsertOneAsync(user);

			return Ok("User registered successfully.");
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] User user)
		{
			var existingUser = await _users.Find(u => u.Username == user.Username).FirstOrDefaultAsync();
			if (existingUser == null || !PasswordHasher.VerifyPassword(user.Password, existingUser.Password))
			{
				return Unauthorized("Invalid credentials.");
			}

			var accessToken = _authService.GenerateAccessToken(user.Username);
			var refreshToken = _authService.GenerateRefreshToken();

			existingUser.RefreshTokens.Add(refreshToken);
			await _users.ReplaceOneAsync(u => u.Id == existingUser.Id, existingUser);

			return Ok(new
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			});
		}

		[HttpPost("refresh")]
		public async Task<IActionResult> Refresh([FromBody] string refreshToken)
		{
			var user = await _users.Find(u => u.RefreshTokens.Contains(refreshToken)).FirstOrDefaultAsync();
			if (user == null)
			{
				return Unauthorized("Invalid refresh token.");
			}

			user.RefreshTokens.Remove(refreshToken);

			var newAccessToken = _authService.GenerateAccessToken(user.Username);
			var newRefreshToken = _authService.GenerateRefreshToken();

			user.RefreshTokens.Add(newRefreshToken);
			await _users.ReplaceOneAsync(u => u.Id == user.Id, user);

			return Ok(new
			{
				AccessToken = newAccessToken,
				RefreshToken = newRefreshToken
			});
		}
	}
}