using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.EntityFrameworkQuery;

public class ActivitiesRepository(ToDoListContext context) : Repository, IActivitiesRepository
{
	public async Task<List<Activity>> GetAll(int listId)
	{
		return await (from act in context.Activities.AsNoTracking() where act.ToDoListId == listId select act).ToListAsync();
	}
}
