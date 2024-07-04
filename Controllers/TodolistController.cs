using Microsoft.AspNetCore.Mvc;
using Todolist.Services;
using Todolist.Models;
using Todolist.Dtos;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Windows.Markup;

namespace Todolist.Controllers;

[ApiController]
[Route("api/tarefas")]
public class TodolistController: ControllerBase {
    private readonly TodolistTaskService _todolistTaskService;

    public TodolistController(TodolistTaskService todolistTaskService) {
        _todolistTaskService = todolistTaskService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TodolistTask>>> GetTasks() {
        var tasks = await _todolistTaskService.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(string id) {
        var task = await _todolistTaskService.GetOneByIdAsync(id);
            if (task == null) {
                return NotFound();
            }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> PostTask([FromBody] CreateTaskDto task) {
        var result = await _todolistTaskService.CreateAsync(task);
        return StatusCode((int)result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(string id, [FromBody] UpdateTaskDto task) {
        var result = await _todolistTaskService.UpdateByIdAsync(id, task);
        return StatusCode((int)result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(string id) {
        var result = await _todolistTaskService.DeleteAsync(id);
        return StatusCode((int)result);
    }
}