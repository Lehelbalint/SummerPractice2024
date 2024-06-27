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
	public class OverviewTaskController
	{
		string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";
		public List<Activity> GetActivitiesByDate(DateTime startdate, DateTime endDate)
		{
			string getActivitiesByDateRange = "tm.GetActivitiesForUserBySpecificDateByRange";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(getActivitiesByDateRange, connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						command.Parameters.AddWithValue("@SpecificDateRange1", startdate);
						command.Parameters.AddWithValue("@SpecificDateRange2", endDate);
						command.ExecuteNonQuery();
						SqlDataReader reader = command.ExecuteReader();
						List<Activity> activitiesByDateRange = new();
						while (reader.Read())
						{
							Activity activity = new Activity
							{
								Id = (int)reader["id"],
								ActivityDescription = (string)reader["activity_description"],
								ProjectTypeDescription = (string)reader["project_type_description"],
								ActivityType_Id = (TaskTypeEnum)(int)reader["activity_type_id"],
								Status_Id = (StatusEnum)(int)reader["status_id"]
							};
							activitiesByDateRange.Add(activity);
						}
						return activitiesByDateRange;
					};
				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred: " + ex.Message);
					return new List<Activity>();
				}
			};
		}

		public List<Activity> GetDailyTasksForAll(DateTime date)
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
						command.Parameters.AddWithValue("@CreationDate", date);
						command.ExecuteNonQuery();
						//Console.WriteLine("Request Succefull");
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
