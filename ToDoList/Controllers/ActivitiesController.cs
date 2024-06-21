using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;
using ToDoList.ViewModels.Activities;

namespace ToDoList.Controllers;

public class ActivitiesController(IActivitiesService activitiesService) : Controller
{
	public async Task<IActionResult> Index(int listId)
	{
		var listWithActivitiesViewModel = await activitiesService.GetAll(listId);
		return View(listWithActivitiesViewModel);
	}

	public async Task<IActionResult> Create(ListWithActivitiesViewModel model)
	{
		var activity = await activitiesService.Create(model);
		return Json(activity);
	}

	public async Task<IActionResult> Update(ActivityViewModel model)
	{
		await activitiesService.Update(model);
		return Json(model);
	}

	public async Task<IActionResult> Delete(int activityId)
	{
		await activitiesService.Delete(activityId);
		return Json(activityId);
	}
}
