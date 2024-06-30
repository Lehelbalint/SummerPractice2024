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
	public class PlotController
	{
		string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";

		public List<PlotType> GetActivitesPerDay(DateTime startDate, DateTime endDate)
		{
			string Procedure = "tm.TasksPerInterval";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(Procedure, connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						command.Parameters.AddWithValue("@startDate", startDate);
						command.Parameters.AddWithValue("@endDate", endDate);
						command.ExecuteNonQuery();

						SqlDataReader reader = command.ExecuteReader();

						List<PlotType> plotTypeList = new List<PlotType>();
						while (reader.Read())
						{
							PlotType plotType = new PlotType
							{
								Date = (DateTime)reader["creation_date"],
								ActivityCount = (int)reader["taskPerDay"]
							};
							plotTypeList.Add(plotType);
						}

						//Console.WriteLine(activities.Count);
						return plotTypeList;
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine("An error occurred: " + ex.Message);
					return new List<PlotType>();
				}
			};

		}
	}
}
