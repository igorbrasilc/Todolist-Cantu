using Todolist.Models;
using MongoDB.Driver;
using System.Net;
using Todolist.Dtos;
using Todolist.Repositories;

namespace Todolist.Services;

public class TodolistTaskService {
    private readonly ITodolistTaskRepository _repository;

        public TodolistTaskService(ITodolistTaskRepository repository) {
            _repository = repository;
        }

    public async Task<HttpStatusCode> CreateAsync(CreateTaskDto createTaskDto) {
        var todolistTask = createTaskDto.ToTodolistTask();
        await _repository.CreateAsync(todolistTask);
        return HttpStatusCode.Created;
    }

    public async Task<List<TodolistTask>> GetAllAsync() {
        var tasks = await _repository.GetAllAsync();
        return tasks.ToList();
    }

    public async Task<TodolistTask> GetOneByIdAsync(string id) {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<HttpStatusCode> UpdateByIdAsync(string id, UpdateTaskDto updateTaskDto) {
        var existingTask = await _repository.GetByIdAsync(id) ?? throw new Exception("Task not found");
        var updatedTask = updateTaskDto.ToTodolistTask(existingTask);
        await _repository.UpdateAsync(updatedTask);
        return HttpStatusCode.OK;
    }

    public async Task<HttpStatusCode> DeleteAsync(string id) {
        await _repository.DeleteAsync(id);
            return HttpStatusCode.OK;
    }
}
