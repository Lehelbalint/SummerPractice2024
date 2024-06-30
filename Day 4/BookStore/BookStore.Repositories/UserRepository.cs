using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IMongoCollection<User> _users;

		public UserRepository(IDatabaseConfiguration dbConfig)
		{
			var client = new MongoClient(dbConfig.ConnectionString);
			var database = client.GetDatabase(dbConfig.DatabaseName);
			_users = database.GetCollection<User>("Users");
		}

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			return _users.Find(user => user.Username == username && user.Password == password).FirstOrDefault();
		}
	}
}
