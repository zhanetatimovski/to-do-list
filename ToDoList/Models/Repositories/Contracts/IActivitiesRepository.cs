using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Models.Repositories.Contracts;

public interface IActivitiesRepository
{
	Task<List<Activity>> GetAll(int listId);
}
