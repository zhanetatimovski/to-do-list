using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Repositories.Contracts;
using ToDoList.ViewModels.Home;

namespace ToDoList.Controllers;

public class HomeController(IToDoListsRepository toDoListsRepository) : Controller
{
	public async Task<IActionResult> Index()
	{
		var toDoLists = await toDoListsRepository.GetAll();
		var toDoListViewModels = new List<ToDoListViewModel>();

		foreach (var toDoList in toDoLists)
		{
			toDoListViewModels.Add(new ToDoListViewModel
			{
				Id = toDoList.Id,
				Name = toDoList.Name
			});
		}

		return View(toDoListViewModels);
	}

	public IActionResult ErrorNotFound()
	{
		return View();
	}
}
