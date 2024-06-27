using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TM.DailyTrackR.DataType.Enums;

namespace TM.DailyTrackR.Logic
{
	public class InsertTaskController
	{
		string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";

		public int InsertActivity(int project_type_id, int activity_type_id, string description, string username, int status_id, DateTime? creationDate)
		{
			string insertProcedure = "tm.InsertActivity";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					if (creationDate == null)
					{
						creationDate = DateTime.Now;
					}

					using (SqlCommand command = new SqlCommand(insertProcedure, connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						command.Parameters.AddWithValue("@activity_type_id", activity_type_id);
						command.Parameters.AddWithValue("@project_type_id", project_type_id);
						command.Parameters.AddWithValue("@description", description);
						command.Parameters.AddWithValue("@status_id", status_id);
						command.Parameters.AddWithValue("@username", username);
						command.Parameters.AddWithValue("@creation_date", creationDate);
						command.ExecuteNonQuery();

						MessageBox.Show("Task inserted");
					};

				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred: " + ex.Message);
				}
			};

			return 0;
		}

	}
}
