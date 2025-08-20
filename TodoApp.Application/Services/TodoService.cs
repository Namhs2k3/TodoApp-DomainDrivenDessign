using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TodoItem>> GetAllAsync() => _repository.GetAllAsync();
        public Task<TodoItem?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public async Task<TodoItem> CreateAsync(string title)
        {
            var todo = new TodoItem(title);
            await _repository.AddAsync(todo);
            return todo;
        }

        public async Task UpdateAsync(Guid id, string title, bool isCompleted)
        {
            var todo = await _repository.GetByIdAsync(id)
                       ?? throw new Exception("Todo not found");

            todo.Title = title;

            if (isCompleted) todo.MarkComplete();
            else todo.MarkIncomplete();

            await _repository.UpdateAsync(todo);
        }

        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
