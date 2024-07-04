
using System.Net;
using Todolist.Dtos;
using Todolist.Enums;
using Todolist.Models;
using Todolist.Repositories;
using Todolist.Services;
using Moq;
using Xunit;

namespace Todolist.Todolist.Tests.Services
{
    public class TodolistTaskServiceTests
    {
        private readonly Mock<ITodolistTaskRepository> _mockRepository;
        private readonly TodolistTaskService _service;

        public TodolistTaskServiceTests()
        {
            _mockRepository = new Mock<ITodolistTaskRepository>();
            _service = new TodolistTaskService(_mockRepository.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedStatus()
        {
            var createTaskDto = new CreateTaskDto
            {
                Title = "Test Title",
                Description = "Test Description",
                Creation_date = DateTime.Now,
                Status = Status.PENDING
            };

            _mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<TodolistTask>())).Returns(Task.CompletedTask);

            var result = await _service.CreateAsync(createTaskDto);

            Assert.Equal(HttpStatusCode.Created, result);
            _mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<TodolistTask>()), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllTasks()
        {
            var tasks = new List<TodolistTask>
            {
                new() { Id = "1", Title = "Test Title 1" },
                new() { Id = "2", Title = "Test Title 2" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tasks);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count);
            _mockRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetOneByIdAsync_ShouldReturnTask_WhenTaskExists()
        {
            var taskId = "1";
            var task = new TodolistTask { Id = taskId, Title = "Test Title" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync(task);

            var result = await _service.GetOneByIdAsync(taskId);

            Assert.NotNull(result);
            Assert.Equal(taskId, result.Id);
            _mockRepository.Verify(repo => repo.GetByIdAsync(taskId), Times.Once);
        }

        [Fact]
        public async Task GetOneByIdAsync_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            var taskId = "1";

            _mockRepository.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync((TodolistTask)null);

            var result = await _service.GetOneByIdAsync(taskId);

            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetByIdAsync(taskId), Times.Once);
        }

        [Fact]
        public async Task UpdateByIdAsync_ShouldReturnOkStatus_WhenTaskExists()
        {
            var taskId = "1";
            var updateTaskDto = new UpdateTaskDto
            {
                Title = "Updated Title",
                Description = "Updated Description",
                Conclusion_date = DateTime.Now,
                Status = Status.CONCLUDED
            };
            var existingTask = new TodolistTask { Id = taskId, Title = "Original Title" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync(existingTask);

            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<TodolistTask>())).Returns(Task.CompletedTask);

            var result = await _service.UpdateByIdAsync(taskId, updateTaskDto);

            Assert.Equal(HttpStatusCode.OK, result);
            _mockRepository.Verify(repo => repo.GetByIdAsync(taskId), Times.Once);
            _mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<TodolistTask>()), Times.Once);
        }

        [Fact]
        public async Task UpdateByIdAsync_ShouldThrowException_WhenTaskDoesNotExist()
        {
            var taskId = "1";
            var updateTaskDto = new UpdateTaskDto
            {
                Title = "Updated Title",
                Description = "Updated Description",
                Conclusion_date = DateTime.Now,
                Status = Status.CONCLUDED
            };

            _mockRepository.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync((TodolistTask)null);

            await Assert.ThrowsAsync<Exception>(() => _service.UpdateByIdAsync(taskId, updateTaskDto));
            _mockRepository.Verify(repo => repo.GetByIdAsync(taskId), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnOkStatus_WhenTaskExists()
        {
            var taskId = "1";

            _mockRepository.Setup(repo => repo.DeleteAsync(taskId)).Returns(Task.CompletedTask);

            var result = await _service.DeleteAsync(taskId);

            Assert.Equal(HttpStatusCode.OK, result);
            _mockRepository.Verify(repo => repo.DeleteAsync(taskId), Times.Once);
        }
    }
}