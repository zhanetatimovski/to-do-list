using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.AdoDotNet;

public class ActivitiesRepository : Repository, IActivitiesRepository
{
	public async Task<IReadOnlyList<Activity>> GetAll(int listId)
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

	public bool IsUnique(string activityName)
	{
		throw new System.NotImplementedException();
	}

	public async Task<Activity?> GetById(int activityId)
	{
		throw new System.NotImplementedException();
	}

	public async Task<Activity> Create(Activity activity)
	{
		throw new System.NotImplementedException();
	}

	public async Task Update(Activity activity)
	{
		throw new System.NotImplementedException();
	}

	public async Task Delete(Activity activity)
	{
		throw new System.NotImplementedException();
	}
}
