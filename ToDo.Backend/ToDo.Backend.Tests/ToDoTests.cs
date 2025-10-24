using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDo.Backend.API.Controllers;
using ToDo.Backend.Application.Interface;
using ToDo.Backend.Domain.Models;

namespace ToDo.Backend.Tests
{
    public class ToDoTests
    {
        private readonly Mock<IToDoService> _mockService;
        private readonly ToDoController _controller;

        public ToDoTests()
        {
            _mockService = new Mock<IToDoService>();
            _controller = new ToDoController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WithListOfItems()
        {
            var expectedItems = new List<ToDoItem>
            {
                new ToDoItem { Id = 1, Title = "Task 1", IsCompleted = false },
                new ToDoItem { Id = 2, Title = "Task 2", IsCompleted = true }
            };

            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(expectedItems);

            var result = await _controller.GetAll();

            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(expectedItems);
        }

        [Fact]
        public async Task GetById_ShouldReturnOk_WhenItemExists()
        {
            var item = new ToDoItem { Id = 1, Title = "Test task" };
            _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(item);

            var result = await _controller.GetById(1);

            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            _mockService.Setup(s => s.GetByIdAsync(999)).ReturnsAsync((ToDoItem?)null);

            var result = await _controller.GetById(999);

            var notFound = result.Result as NotFoundObjectResult;
            notFound.Should().NotBeNull();
            notFound!.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Create_ShouldReturnCreated_WhenModelIsValid()
        {
            var newItem = new ToDoItem { Id = 1, Title = "New Task" };
            _mockService.Setup(s => s.AddAsync(It.IsAny<ToDoItem>())).Returns(Task.CompletedTask);

            var result = await _controller.Create(newItem);

            var created = result as CreatedAtActionResult;
            created.Should().NotBeNull();
            created!.StatusCode.Should().Be(201);
            created.Value.Should().BeEquivalentTo(newItem);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenModelIsInvalid()
        {
            _controller.ModelState.AddModelError("Title", "Required");

            var result = await _controller.Create(new ToDoItem());

            var badRequest = result as BadRequestObjectResult;
            badRequest.Should().NotBeNull();
            badRequest!.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContent_WhenItemExists()
        {
            var item = new ToDoItem { Id = 1, Title = "Updated Task" };
            _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(item);
            _mockService.Setup(s => s.UpdateAsync(item)).Returns(Task.CompletedTask);

            var result = await _controller.Update(1, item);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequest_WhenIdsDoNotMatch()
        {
            var item = new ToDoItem { Id = 1, Title = "Wrong ID" };

            var result = await _controller.Update(2, item);

            var badRequest = result as BadRequestObjectResult;
            badRequest.Should().NotBeNull();
            badRequest!.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            var item = new ToDoItem { Id = 999, Title = "Non-existing" };
            _mockService.Setup(s => s.GetByIdAsync(999)).ReturnsAsync((ToDoItem?)null);

            var result = await _controller.Update(999, item);

            var notFound = result as NotFoundObjectResult;
            notFound.Should().NotBeNull();
            notFound!.StatusCode.Should().Be(404);
        }
    }
}
 