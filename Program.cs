using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Todolist.Services;
using Todolist.Models;
using Todolist.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<TodolistTaskService>();
builder.Services.AddSingleton<ITodolistTaskRepository, TodolistTaskRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList V1");
    });

app.UseRouting();
app.MapControllers();

await app.RunAsync();

