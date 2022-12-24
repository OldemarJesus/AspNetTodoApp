using ManagementSystem.Entities;
using ManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private TodoItemService _todoItemService;

        public List<TodoItem> Data { get; private set; } = new List<TodoItem>();
        public string? Status { get; set; } = "Nothing for now";

        public IndexModel(ILogger<IndexModel> logger, TodoItemService itemService)
        {
            _logger = logger;
            _todoItemService = itemService;
        }

        public void OnGet()
        {
            Data = _todoItemService.GetAll().ToList();
        }

        public void OnPost()
        {
            string title = Request.Form["title"];
            string description = Request.Form["description"];
            string action = Request.Form["action"];

            if (title == null || description == null)
            {
                return;
            }

            if(action.Equals("add")) addTodo(title, description);
            if(action.Equals("del")) removeTodo(title, description);
        }

        private void removeTodo(string title, string description)
        {
            TodoItem todoItem = new TodoItem();
            todoItem.Title = title;
            todoItem.Description = description;

            Status = _todoItemService.Del(todoItem) ? "Removed" : "Fail to remove";

            Data = _todoItemService.GetAll().ToList();
        }

        private void addTodo(string title, string description)
        {
            Status = _todoItemService.Add(title, description) ? "Added" : "Fail to add";

            Data = _todoItemService.GetAll().ToList();
        }
    }
}