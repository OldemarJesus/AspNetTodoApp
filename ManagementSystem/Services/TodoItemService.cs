using ManagementSystem.Entities;
using System.Collections.ObjectModel;

namespace ManagementSystem.Services
{
    public class TodoItemService
    {
        private IEnumerable<TodoItem> TodoItem = new Collection<TodoItem>();

        public bool Add(String title, String description)
        {
            TodoItem item = new TodoItem
            {
                Title = title,
                Description = description,
                isFinished = false
            };

            TodoItem = TodoItem.Append(item);
            return true;
        }

        public bool Del(TodoItem item)
        {
            bool removed = TodoItem.Contains(item);

            TodoItem = TodoItem.Where(todo =>
            {
                return !todo.Equals(item);
            });

            return removed;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItem;
        }
    }
}
