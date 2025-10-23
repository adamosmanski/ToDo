using ToDo.Backend.API.Interface;
using ToDo.Backend.API.Models;

namespace ToDo.Backend.API.Serivce
{
    public class ToDoService : IToDoService
    {
        public Task AddAsync(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
