using BookStore.Application;
using BookStore.Data.Abstractions;
using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookStore.Controllers
{

    [ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly AuthenticationService _tokenService;
		private readonly RefreshTokenService _refreshTokenService;
		private readonly IUserRepository _userRepository;

		public AuthController(AuthenticationService tokenService, RefreshTokenService refreshTokenService, IUserRepository userRepository)
		{
			_tokenService = tokenService;
			_refreshTokenService = refreshTokenService;
			_userRepository = userRepository;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			var userId = ValidateUserCredentials(request.Username, request.Password);
			if (userId == null)
			{
				return Unauthorized();
			}

			var accessToken = _tokenService.GenerateAccessToken(userId);
			var refreshToken = _refreshTokenService.GenerateRefreshToken(userId);

			return Ok(new
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken.Token
			});
		}

		[HttpPost("refresh-token")]
		public IActionResult RefreshToken([FromBody] RefreshTokenRequest request)
		{
			if (!_refreshTokenService.ValidateRefreshToken(request.RefreshToken, request.UserId))
			{
				return Unauthorized();
			}

			var newAccessToken = _tokenService.GenerateAccessToken(request.UserId);
			return Ok(new
			{
				AccessToken = newAccessToken
			});
		}

		private string ValidateUserCredentials(string username, string password)
		{
			var user = _userRepository.GetUserByUsernameAndPassword(username, password);
			return user?.Id;
		}
	}
	}