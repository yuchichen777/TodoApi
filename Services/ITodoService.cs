using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Task CreateTodoItem(TodoItem todoItem);
        Task<TodoItem> GetTodoItem(int id);
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task UpdateTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(int id);
    }
}
