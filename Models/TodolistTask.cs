using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using Todolist.Enums;

namespace Todolist.Models;

public class TodolistTask {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; } = null;

    public DateTime Creation_date { get; set; } = DateTime.Now;

    public DateTime? Conclusion_date { get; set; } = null;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; set; } = Status.PENDING;
}
