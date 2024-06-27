using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DailyTrackR.DataType.Enums;
using TM.DailyTrackR.DataType;

namespace TM.DailyTrackR.Logic
{
	public class LoginController
	{
		string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";

		public User Login(string username, string password)
		{
			//string procedureName = "tm.GetAllProjectTypes";
			string LoginProcedure = "tm.login";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(LoginProcedure, connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						command.Parameters.AddWithValue("@username", username);
						command.Parameters.AddWithValue("@password", password);
						command.ExecuteNonQuery();

						//Console.WriteLine("Request Succesfull");
						SqlDataReader reader = command.ExecuteReader();

						reader.Read();
						User loggedUser = new User
						{
							username = (string)reader["username"],
							role = (RoleEnum)(int)reader["role"]
						};

						//Console.WriteLine(activities.Count);
						return loggedUser;
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred: " + ex.Message);
					return new User();
				}
			};

		}
	}
}
