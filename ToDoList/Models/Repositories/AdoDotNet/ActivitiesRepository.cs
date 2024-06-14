using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.AdoDotNet;

public class ActivitiesRepository : Repository, IActivitiesRepository
{
	public async Task<List<Activity>> GetAll(int listId)
	{
		var activities = new List<Activity>();

		using (var conn = new SqlConnection(ConnectionString))
		{
			conn.Open();

			var cmd = new SqlCommand("SELECT * FROM [Activities] WHERE ToDoListId = @ToDoListId", conn);
			cmd.Parameters.AddWithValue("ToDoListId", listId);

			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (reader.Read())
			{
				activities.Add(new Activity
				{
					Name = (string)reader["Name"],
					IsDone = (bool)reader["IsDone"]
				});
			}
		}

		return activities;
	}
}
