using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            IsCompleted = false;
        }

        [JsonConstructor]
        public TodoItem(string title, bool isCompleted)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            IsCompleted = isCompleted;
        }

        public void MarkComplete() => IsCompleted = true;
        public void MarkIncomplete() => IsCompleted = false;
    }
}
