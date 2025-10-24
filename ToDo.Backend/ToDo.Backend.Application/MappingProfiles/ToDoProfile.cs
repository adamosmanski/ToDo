using AutoMapper;

namespace ToDo.Backend.API.MappingProfiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<Domain.Models.ToDoItem, Data.Model.ToDoItem>().ReverseMap();
        }
    }
}
