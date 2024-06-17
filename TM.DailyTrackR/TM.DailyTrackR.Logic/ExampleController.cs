namespace TM.DailyTrackR.Logic
{
	using System.Data;
	using System.Data.SqlClient;

  public sealed class ExampleController
  {
    string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";

    public int GetDataExample()
    {
            //string procedureName = "tm.GetAllProjectTypes";
            string insertProcedure = "tm.InsertProjectType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                       command.Parameters.AddWithValue("@Description", "TestFromApp");
						//command.Parameters.AddWithValue("@param2", value2);

						command.ExecuteNonQuery();

                        Console.WriteLine("Row inserted");
						//SqlDataReader reader = command.ExecuteReader();
						//Dictionary<int, string> result = new();
						//while (reader.Read())
						//{
						//  result.Add((int)reader["project_type_id"], (string)reader["project_type_description"]);
						//}
					}  ;
                   // string version = (string)command.ExecuteScalar();
                    //System.Diagnostics.Debug.WriteLine("SQL Server Version: " + version);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            };

      return 0;
    }
  }
}
