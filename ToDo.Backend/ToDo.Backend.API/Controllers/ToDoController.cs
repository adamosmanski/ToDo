using Microsoft.AspNetCore.Mvc;
using ToDo.Backend.API.Interface;
using ToDo.Backend.API.Models;

namespace ToDo.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAll()
        {
            var items = await _toDoService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetById(int id)
        {
            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"ToDo item with id {id} not found.");

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ToDoItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _toDoService.AddAsync(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ToDoItem item)
        {
            if (id != item.Id)
                return BadRequest("ID in URL and body do not match.");

            var existing = await _toDoService.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"ToDo item with id {id} not found.");

            await _toDoService.UpdateAsync(item);
            return NoContent();
        }
    }
}