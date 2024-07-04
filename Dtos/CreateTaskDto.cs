
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Todolist.Enums;
using Todolist.Models;

namespace Todolist.Dtos;

public class CreateTaskDto {
    [Required]
    public string Title { get; set; } = null!;

    public string? Description { get; set; } = null;
    
    [Required]
    public DateTime Creation_date { get; set; } = DateTime.Now;

    public DateTime? Conclusion_date { get; set; } = null;

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; set; } = Status.PENDING;

    public TodolistTask ToTodolistTask() {
        return new TodolistTask {
            Title = this.Title,
            Description = this.Description,
            Creation_date = this.Creation_date,
            Conclusion_date = this.Conclusion_date,
            Status = this.Status
        };
    }
}