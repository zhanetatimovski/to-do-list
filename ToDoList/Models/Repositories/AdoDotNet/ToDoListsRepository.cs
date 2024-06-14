using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.AdoDotNet;

public class ToDoListsRepository : Repository, IToDoListsRepository
{
	public async Task<List<ToDoList>> GetAll()
	{
		var toDoLists = new List<ToDoList>();

		using (var conn = new SqlConnection(ConnectionString))
		{
			conn.Open();

			var cmd = new SqlCommand("SELECT * FROM [ToDoLists]", conn);

			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (reader.Read())
			{
				toDoLists.Add(new ToDoList
				{
					Id = (int)reader["Id"],
					Name = reader["Name"].ToString()
				});
			}
		}

		return toDoLists;
	}

	public async Task<ToDoList> Get(int id)
	{
		ToDoList toDoList = null;

		using (var conn = new SqlConnection(ConnectionString))
		{
			conn.Open();

			var cmd = new SqlCommand("SELECT * FROM [ToDoLists] WHERE Id = @Id", conn);
			cmd.Parameters.AddWithValue("Id", id);

			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (reader.Read())
			{
				toDoList = new ToDoList
				{
					Id = (int)reader["Id"],
					Name = reader["Name"].ToString()
				};
			}
		}

		return toDoList;
	}
}
