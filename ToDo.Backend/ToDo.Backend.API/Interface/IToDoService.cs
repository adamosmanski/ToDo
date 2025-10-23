using ToDo.Backend.API.Models;

namespace ToDo.Backend.API.Interface
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task SaveChangesAsync();
    }
}
