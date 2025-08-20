using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public bool IsCompleted { get; private set; }

        public TodoItem(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            IsCompleted = false;
        }

        public void MarkComplete() => IsCompleted = true;
        public void MarkIncomplete() => IsCompleted = false;
    }
}
