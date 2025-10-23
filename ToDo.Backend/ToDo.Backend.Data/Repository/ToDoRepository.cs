using Microsoft.EntityFrameworkCore;
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
        private readonly ToDoContext _context;
        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ToDoItem item)
        {
            await _context.ToDoItems.AddAsync(item);
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            var existing = await _context.ToDoItems.FindAsync(item.Id);
            if (existing == null) return;

            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.IsCompleted = item.IsCompleted;
        }
    }
}
