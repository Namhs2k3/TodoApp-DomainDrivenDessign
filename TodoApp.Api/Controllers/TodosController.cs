using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;
using TodoApp.Domain.Entities;

namespace TodoApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoService _service;

        public TodosController(TodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAll()
            => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetById(Guid id)
        {
            var todo = await _service.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create([FromBody] string title)
        {
            var todo = await _service.CreateAsync(title);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TodoItem input)
        {
            await _service.UpdateAsync(id, input.Title, input.IsCompleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
