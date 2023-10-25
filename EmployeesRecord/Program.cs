using EmployeesRecord.Data;
using EmployeesRecord.Services;
using EmployeesRecord.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Create DataBase
ApplicationContext.GetInstance();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<IPositionService, PositionService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();



app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
