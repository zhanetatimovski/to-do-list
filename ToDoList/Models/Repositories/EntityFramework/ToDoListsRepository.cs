using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.EntityFramework;

public class ToDoListsRepository(ToDoListContext context) : Repository, IToDoListsRepository
{
	public async Task<ToDoList> Get(int id)
	{
		return await context.ToDoLists.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task<List<ToDoList>> GetAll()
	{
		return await context.ToDoLists.AsNoTracking().ToListAsync();
	}
}
