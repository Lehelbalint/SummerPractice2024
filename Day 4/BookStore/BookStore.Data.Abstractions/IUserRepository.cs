using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Abstractions
{
	public interface IUserRepository
	{
		User GetUserByUsernameAndPassword(string username, string password);
	}
}
