using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.Repositories.Contracts;
using ToDoList.ViewModels.Activities;

namespace ToDoList.Controllers;

public class ActivitiesController(IToDoListsRepository toDoListsRepository, IActivitiesRepository activitiesRepository) : Controller
{
	public async Task<IActionResult> Index(int listId)
	{
		var toDoList = await toDoListsRepository.Get(listId);
		if (toDoList == null)
		{
			return RedirectToAction("ErrorNotFound");
		}

		var listWithActivitiesViewModel = new ListWithActivitiesViewModel
		{
			Name = toDoList.Name
		};

		List<Activity> activities = await activitiesRepository.GetAll(listId);
		foreach (var activity in activities)
		{
			listWithActivitiesViewModel.Activities.Add(new ActivityViewModel
			{
				Id = activity.Id,
				Name = activity.Name,
				IsDone = activity.IsDone
			});
		}

		return View(listWithActivitiesViewModel);
	}
}
