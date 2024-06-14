using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.EntityFrameworkQuery
{
	public class ToDoListsRepository(ToDoListContext context) : Repository, IToDoListsRepository
	{
		public async Task<ToDoList> Get(int id)
		{
			return await (from tdl in context.ToDoLists.AsNoTracking() where tdl.Id == id select tdl).FirstOrDefaultAsync();
		}

		public async Task<List<ToDoList>> GetAll()
		{
			return await (from tdl in context.ToDoLists.AsNoTracking() select tdl).ToListAsync();
		}
	}
}
