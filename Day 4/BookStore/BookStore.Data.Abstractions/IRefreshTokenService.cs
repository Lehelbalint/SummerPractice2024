using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Abstractions
{
	public interface IRefreshTokenService
	{
		RefreshToken GenerateRefreshToken(string userId);
		bool ValidateRefreshToken(string token, string userId);
		void RevokeRefreshToken(string token, string userId);
	}
}
