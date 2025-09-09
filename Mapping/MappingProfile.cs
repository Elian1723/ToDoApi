using AutoMapper;
using ToDoApi.Models;
using ToDoApi.Models.DTOs;

namespace ToDoApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();

        CreateMap<ToDo, ToDoDto>();
        CreateMap<ToDoCreateDto, ToDo>();
        CreateMap<ToDoUpdateDto, ToDo>();
    }
}
