using AutoMapper;
using ToDo.Backend.API.Interface;
using ToDo.Backend.API.Models;
using ToDo.Backend.Data.Interface;

namespace ToDo.Backend.API.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(ToDoItem item)
        {
            var entity = _mapper.Map<Data.Model.ToDoItem>(item);
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsCompleted = false;

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoItem>>(items);
        }

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<ToDoItem?>(item);
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            var entity = _mapper.Map<Data.Model.ToDoItem>(item);
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
