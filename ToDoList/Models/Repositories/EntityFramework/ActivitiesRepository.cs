using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.EntityFramework;

public class ActivitiesRepository(ToDoListContext context) : Repository, IActivitiesRepository
{
	public async Task<List<Activity>> GetAll(int listId)
	{
		return await context.Activities.AsNoTracking().Where(x => x.ToDoListId == listId).ToListAsync();
	}
}
