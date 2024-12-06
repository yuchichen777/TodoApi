using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<TodoItem> _todoRepo;

        public TodoService(IRepository<TodoItem> todoRepo) 
        {
            _todoRepo = todoRepo;
        }

        public async Task CreateTodoItem(TodoItem todoItem)
        {
            await _todoRepo.CreateAsnyc(todoItem);
        }

        public async Task DeleteTodoItem(int id)
        {
            await _todoRepo.DeleteAsnyc(id);
        }

        public Task<TodoItem> GetTodoItem(int id)
        {
            return _todoRepo.FindByIdAsnyc(id);
        }

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return _todoRepo.GetAllAsnyc();
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            await _todoRepo.UpdateAsnyc(todoItem);
        }
    }
}
