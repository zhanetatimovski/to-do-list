using System.Collections.Generic;

namespace ToDoList.ViewModels.Activities;

public class ListWithActivitiesViewModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public List<ActivityViewModel> Activities { get; set; }
}
