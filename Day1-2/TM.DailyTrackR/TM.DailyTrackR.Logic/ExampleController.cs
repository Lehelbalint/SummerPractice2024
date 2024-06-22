namespace TM.DailyTrackR.Logic
{
	using System.Data;
	using System.Data.SqlClient;
	using TM.DailyTrackR.DataType;
	using TM.DailyTrackR.DataType.Enums;

	public sealed class ExampleController
	{
		string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";



		public List<Activity> GetDailyTasks()
		{
			//string procedureName = "tm.GetAllProjectTypes";
			string getDailyTaskProcedure = "tm.GetActivitiesByDateAndUserNameJoined";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(getDailyTaskProcedure, connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						command.Parameters.AddWithValue("@CreationDate", "2024-06-12");
						command.Parameters.AddWithValue("UserName", "User A");
						command.ExecuteNonQuery();

						Console.WriteLine("Request Succefull");
						SqlDataReader reader = command.ExecuteReader();
						List<Activity> activities = new();
						while (reader.Read())
						{
							Activity activity = new Activity
							{
								Id = (int)reader["id"],
								ActivityDescription = (string)reader["adescription"],
								ProjectTypeDescription = (string)reader["ptdescription"],
								UserName = (string)reader["username"],
								ActivityType_Id = (TaskTypeEnum)(int)reader["activity_type_id"],
								Status_Id = (StatusEnum)(int)reader["status_id"]
							};
							activities.Add(activity);
						}
						Console.WriteLine(activities.Count);
						return activities;
						//activities.Add()
						// activities.Add((int)reader["project_type_id"], (string)reader["project_type_description"]);
						//}
						// string version = (string)command.ExecuteScalar();
						//System.Diagnostics.Debug.WriteLine("SQL Server Version: " + version);
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred: " + ex.Message);
					return new List<Activity>();
				}
			};

		}

		public List<Activity> GetDailyTasksForAll()
		{
			string getDailyTaskForAllProcedure = "tm.GetActivitiesByDate";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(getDailyTaskForAllProcedure, connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						command.Parameters.AddWithValue("@CreationDate", "2024-06-12");
						command.ExecuteNonQuery();
						//Console.WriteLine("Request Succefull");
						SqlDataReader reader = command.ExecuteReader();
						List<Activity> activities = new();
						while (reader.Read())
						{
							Activity activity = new Activity
							{
								Id = (int)reader["id"],
								ActivityDescription = (string)reader["adescription"],
								ProjectTypeDescription = (string)reader["ptdescription"],
								UserName = (string)reader["username"],
								ActivityType_Id = (TaskTypeEnum)(int)reader["activity_type_id"],
								Status_Id = (StatusEnum)(int)reader["status_id"]
							};
							activities.Add(activity);
						}
						Console.WriteLine(activities.Count);
						return activities;
						//activities.Add()
						// activities.Add((int)reader["project_type_id"], (string)reader["project_type_description"]);
						//}
						// string version = (string)command.ExecuteScalar();
						//System.Diagnostics.Debug.WriteLine("SQL Server Version: " + version);
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred: " + ex.Message);
					return new List<Activity>();
				}
			};

		}
	}

}

//  public int GetDataExample()
//  {
//    string query = "SELECT @@VERSION";

//    using SqlConnection connection = new SqlConnection(connectionString);

//    try
//    {
//      connection.Open();

//      using SqlCommand command = new SqlCommand(query, connection);
//      string version = (string)command.ExecuteScalar();
//      System.Diagnostics.Debug.WriteLine("SQL Server Version: " + version);
//connection.Close();
//    }
//    catch (Exception ex)
//    {
//      Console.WriteLine("An error occurred: " + ex.Message);
//    }

//    return 0;
//  }