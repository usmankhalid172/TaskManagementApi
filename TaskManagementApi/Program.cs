using TaskManagementApi.BusinessLogic.IServices;
using TaskManagementApi.BusinessLogic.Polly;
using TaskManagementApi.BusinessLogic.Services;
using TaskManagementApi.DataAccess.IRepositories;
using TaskManagementApi.DataAccess.Repositories;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console()
          .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
          .Enrich.FromLogContext();
});
// Add services to the container.
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITaskService, TaskService>();
builder.Services.AddSingleton<IRetryPolicy, RetryPolicy>();
builder.Services.AddSingleton<IRetryPolicy, RetryPolicy>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
