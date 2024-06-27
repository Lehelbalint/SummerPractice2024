namespace TM.DailyTrackR.Logic
{
	using System.Data;
	using System.Data.SqlClient;
	using System.Windows;
	using TM.DailyTrackR.DataType;
	using TM.DailyTrackR.DataType.Enums;

	public sealed class DailyTaskController
	{
		string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";

		public int UpdateActivity(Activity activity)
		{
			string updateProcedure = "tm.UpdateActivityById";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(updateProcedure, connection))
					{

						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						ProjectType projectType = (ProjectType)Enum.Parse(typeof(ProjectType), activity.ProjectTypeDescription);
						int projectTypeInt = (int)projectType;
						command.Parameters.AddWithValue("@description", activity.ActivityDescription);
						command.Parameters.AddWithValue("@status_id", (int)activity.Status_Id);
						command.Parameters.AddWithValue("@project_type_id", projectType);
						command.Parameters.AddWithValue("@activity_type_id", (int)activity.ActivityType_Id);
						command.Parameters.AddWithValue("@id",activity.Id);
						//MessageBox.Show("Updated");
						var res = command.ExecuteNonQuery();
						//MessageBox.Show(res.ToString());
					
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				return 0;
			}
		}
		public int DeleteActivity (int id)
		{
			string deleteProcedure = "tm.DeleteActivityById";
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(deleteProcedure, con))
					{
						command.CommandType = CommandType.StoredProcedure;
						con.Open();
						command.Parameters.AddWithValue("@id", id);
						return command.ExecuteNonQuery();
					};
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			return -1;
		}
		public List<Activity> GetDailyTasks(DateTime date, string username)
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
						command.Parameters.AddWithValue("@CreationDate", date);
						command.Parameters.AddWithValue("@UserName", username);
						command.ExecuteNonQuery();

						Console.WriteLine("Request Succefull");
						SqlDataReader reader = command.ExecuteReader();
						List<Activity> activities = new();
						int counter = 0;
						while (reader.Read())
						{	
							counter++;
							Activity activity = new Activity
							{
								No = counter,
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
