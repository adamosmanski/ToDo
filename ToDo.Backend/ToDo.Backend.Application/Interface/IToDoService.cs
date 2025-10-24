

using ToDo.Backend.Domain.Models;

namespace ToDo.Backend.Application.Interface
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
    }
}
