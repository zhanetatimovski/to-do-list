using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.Models.Repositories;
using ToDoList.Models.Repositories.Contracts;
using ToDoList.Models.Repositories.EntityFramework;
using ToDoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoListContext>(options => options.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=ToDoList;Integrated Security=True;TrustServerCertificate=True"));

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IToDoListsRepository, ToDoListsRepository>();
builder.Services.AddTransient<IActivitiesRepository, ActivitiesRepository>();
builder.Services.AddTransient<IActivitiesService, ActivitiesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
