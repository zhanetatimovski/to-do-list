using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Models.Repositories.Contracts;

public interface IActivitiesRepository
{
	Task<IReadOnlyList<Activity>> GetAll(int listId);
	Task<Activity?> GetById(int activityId);
	bool IsUnique(string activityName);
	Task<Activity> Create(Activity activity);
	Task Update(Activity activity);
	Task Delete(Activity activity);
}
