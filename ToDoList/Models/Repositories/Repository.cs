namespace ToDoList.Models.Repositories;

public abstract class Repository
{
	public readonly string ConnectionString = "Data Source=.\\SQLExpress;Initial Catalog=ToDoList;Integrated Security=True";
}
