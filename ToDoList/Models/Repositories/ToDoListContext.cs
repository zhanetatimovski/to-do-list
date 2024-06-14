
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models.Repositories;

public class ToDoListContext : DbContext
{
	public ToDoListContext(DbContextOptions<ToDoListContext> options)
		   : base(options)
	{
	}

	public DbSet<ToDoList> ToDoLists { get; set; }
	public DbSet<Activity> Activities { get; set; }
}
