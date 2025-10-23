using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Backend.Data.Interface;
using ToDo.Backend.Data.Model;

namespace ToDo.Backend.Data.Repository
{
    public class ToDoRepository : IToDoRepository
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
