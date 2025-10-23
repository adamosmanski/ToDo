using AutoMapper;
using ToDo.Backend.API.Models;

namespace ToDo.Backend.API.MappingProfiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoItem, Data.Model.ToDoItem>().ReverseMap();
        }
    }
}
