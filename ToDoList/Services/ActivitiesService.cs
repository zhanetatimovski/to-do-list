using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ToDoList.Models.Repositories.Contracts;
using ToDoList.ViewModels.Activities;
using Activity = ToDoList.Models.Activity;
using ToDoListModel = ToDoList.Models.ToDoList;

namespace ToDoList.Services;

public interface IActivitiesService
{
	Task<ListWithActivitiesViewModel> GetAll(int listId);
	Task<ActivityViewModel> Create(ListWithActivitiesViewModel model);
	Task Update(ActivityViewModel model);
	Task Delete(int activityId);
}

public class ActivitiesService : IActivitiesService
{
	private readonly IToDoListsRepository _toDoListsRepository;
	private readonly IActivitiesRepository _activitiesRepository;
	private readonly ILogger<ActivitiesService> _logger;

	public ActivitiesService(IToDoListsRepository toDoListsRepository, IActivitiesRepository activitiesRepository, ILogger<ActivitiesService> logger)
	{
		_toDoListsRepository = toDoListsRepository;
		_activitiesRepository = activitiesRepository;
		_logger = logger;
	}

	public async Task<ListWithActivitiesViewModel> GetAll(int listId)
	{
		var toDoList = await GetListById(listId);

		var listWithActivitiesViewModel = new ListWithActivitiesViewModel
		{
			Name = toDoList.Name
		};

		var activities = await _activitiesRepository.GetAll(listId);
		listWithActivitiesViewModel.Activities = activities.Select(x => new ActivityViewModel
		{
			Id = x.Id,
			Name = x.Name,
			IsDone = x.IsDone
		}).ToList();

		return listWithActivitiesViewModel;
	}

	public async Task<ActivityViewModel> Create(ListWithActivitiesViewModel model)
	{
		var anyWithTheSameName = _activitiesRepository.IsUnique(model.Name);
		if (anyWithTheSameName)
		{
			throw new Exception("Activty with the same name already exists!");
		}

		var activity = new Activity
		{
			Name = model.Name,
			ToDoListId = model.Id,
			IsDone = false
		};

		try
		{
			var savedActivity = await _activitiesRepository.Create(activity);
			return new ActivityViewModel { Id = savedActivity.Id, Name = savedActivity.Name, IsDone = savedActivity.IsDone };
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, $"Unexpected error in {nameof(Create)}");
			throw new Exception("Something get wrong. Please try again later!");
		}
	}

	public async Task Update(ActivityViewModel model)
	{
		var anyWithTheSameName = _activitiesRepository.IsUnique(model.Name);
		if (anyWithTheSameName)
		{
			throw new Exception("Activty with the same name already exists!");
		};

		var activity = await _activitiesRepository.GetById(model.Id) ?? throw new Exception("Activity not found!");

		activity.Name = model.Name;
		activity.IsDone = model.IsDone;

		try
		{
			await _activitiesRepository.Update(activity);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, $"Unexpected error in {nameof(Update)}");
			throw new Exception("Something get wrong. Please try again later!");
		}
	}

	public async Task Delete(int activityId)
	{
		try
		{
			var activity = await _activitiesRepository.GetById(activityId);
			await _activitiesRepository.Delete(activity!);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, $"Unexpected error in {nameof(Delete)}");
			throw new Exception("Something get wrong. Please try again later!");
		}
	}

	private async Task<ToDoListModel> GetListById(int listId)
	{
		var toDoList = await _toDoListsRepository.Get(listId);
		return toDoList ?? throw new Exception("List not found!");
	}
}