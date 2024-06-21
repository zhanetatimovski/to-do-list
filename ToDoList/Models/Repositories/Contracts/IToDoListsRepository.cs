using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Models.Repositories.Contracts;

public interface IToDoListsRepository
{
	Task<List<ToDoList>> GetAll();
	Task<ToDoList?> Get(int id);
}
