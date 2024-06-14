using System.Collections.Generic;

namespace ToDoList.Models;

public class ToDoList
{
	public ToDoList()
	{
		Activities = new List<Activity>();
	}

	public int Id { get; set; }
	public string Name { get; set; }
	public virtual List<Activity> Activities { get; set; }
}
