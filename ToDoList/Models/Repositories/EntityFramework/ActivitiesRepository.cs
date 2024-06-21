using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Repositories.Contracts;

namespace ToDoList.Models.Repositories.EntityFramework;

public class ActivitiesRepository(ToDoListContext context) : Repository, IActivitiesRepository
{
	public async Task<IReadOnlyList<Activity>> GetAll(int listId)
	{
		return await context.Activities.AsNoTracking().Where(x => x.ToDoListId == listId).ToListAsync();
	}

	public async Task<Activity?> GetById(int activityId)
	{
		return await context.Activities.AsNoTracking().Where(x => x.Id == activityId).FirstOrDefaultAsync();
	}

	public bool IsUnique(string activityName)
	{
		return context.Activities.AsNoTracking().Any(c => c.Name == activityName);
	}

	public async Task<Activity> Create(Activity activity)
	{
		context.Add(activity);
		await context.SaveChangesAsync();
		return activity;
	}

	public async Task Update(Activity activity)
	{
		context.Update(activity);
		await context.SaveChangesAsync();
	}

	public async Task Delete(Activity activity)
	{
		context.Remove(activity);
		await context.SaveChangesAsync();
	}
}
