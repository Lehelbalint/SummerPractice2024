using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Abstractions;

namespace BookStore.Domain
{

	public class RefreshTokenService : IRefreshTokenService
	{
		private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();

		public RefreshToken GenerateRefreshToken(string userId)
		{
			var token = Guid.NewGuid().ToString();
			var refreshToken = new RefreshToken
			{
				Token = token,
				Expires = DateTime.UtcNow.AddDays(7),
				Created = DateTime.UtcNow,
				UserId = userId
			};

			_refreshTokens.Add(refreshToken);
			return refreshToken;
		}

		public bool ValidateRefreshToken(string token, string userId)
		{
			var refreshToken = _refreshTokens.FirstOrDefault(rt => rt.Token == token && rt.UserId == userId);
			return refreshToken != null && refreshToken.IsActive;
		}

		public void RevokeRefreshToken(string token, string userId)
		{
			var refreshToken = _refreshTokens.FirstOrDefault(rt => rt.Token == token && rt.UserId == userId);
			if (refreshToken != null)
			{
				_refreshTokens.Remove(refreshToken);
			}
		}
	}
}
