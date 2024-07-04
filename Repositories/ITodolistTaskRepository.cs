
using MongoDB.Bson;
using Todolist.Models;

namespace Todolist.Repositories;
public interface ITodolistTaskRepository {
    Task<TodolistTask> GetByIdAsync(string id);
    Task<IEnumerable<TodolistTask>> GetAllAsync();
    Task CreateAsync(TodolistTask task);
    Task UpdateAsync(TodolistTask task);
    Task DeleteAsync(string id);
}