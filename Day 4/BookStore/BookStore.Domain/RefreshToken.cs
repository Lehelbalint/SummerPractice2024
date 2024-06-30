using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
	public class RefreshToken
	{
		public string Token { get; set; }
		public DateTime Expires { get; set; }
		public DateTime Created { get; set; }
		public string UserId { get; set; }
		public bool IsExpired => DateTime.UtcNow >= Expires;
		public bool IsActive => !IsExpired;
	}
}
