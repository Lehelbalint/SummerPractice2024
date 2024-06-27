using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DailyTrackR.DataType;

namespace TM.DailyTrackR.Common
{
	public class UserService
	{
		private static UserService _instance;
		private static readonly object _lock = new object();

		public static UserService Instance
		{
			get
			{
				lock (_lock)
				{
					return _instance ?? (_instance = new UserService());
				}
			}
		}

		public User LoggedInUser { get; private set; }

		private UserService() { }

		public void SetLoggedInUser(User user)
		{
			LoggedInUser = user;
		}
	}
}
