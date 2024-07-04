using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Todolist.Models;

namespace Todolist.Repositories;
public class TodolistTaskRepository : ITodolistTaskRepository {
    private readonly IMongoCollection<TodolistTask> _todolistCollection;

    public TodolistTaskRepository(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _todolistCollection = database.GetCollection<TodolistTask>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<TodolistTask> GetByIdAsync(string id) {
        return await _todolistCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TodolistTask>> GetAllAsync() {
        return await _todolistCollection.Find(_ => true).ToListAsync();
    }

    public async Task CreateAsync(TodolistTask task) {
        await _todolistCollection.InsertOneAsync(task);
    }

    public async Task UpdateAsync(TodolistTask task) {
        await _todolistCollection.ReplaceOneAsync(t => t.Id == task.Id, task);
    }

    public async Task DeleteAsync(string id) {
        await _todolistCollection.DeleteOneAsync(t => t.Id == id);
    }
}