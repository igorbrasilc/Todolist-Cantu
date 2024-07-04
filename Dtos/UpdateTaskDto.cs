using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Todolist.Enums;
using Todolist.Models;

namespace Todolist.Dtos;
public class UpdateTaskDto {

    public string? Title { get; set; }

    public string? Description { get; set; }
    
    public DateTime? Conclusion_date { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; set; }

     public TodolistTask ToTodolistTask(TodolistTask existingTask) {
        if (Title != null) {
            existingTask.Title = Title;
        }

        if (Description != null) {
            existingTask.Description = Description;
        }

        if (Conclusion_date != null) {
            existingTask.Conclusion_date = Conclusion_date;
        }

        existingTask.Status = Status;

        return existingTask;
    }
}