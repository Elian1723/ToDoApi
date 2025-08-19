using AutoMapper;
using ToDoApi.DTOs;
using ToDoApi.Models;

namespace ToDoApi.Automappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();

        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();

        CreateMap<ToDo, ToDoDto>();
        CreateMap<ToDoCreateDto, ToDo>();
        CreateMap<ToDoUpdateDto, ToDo>();
    }
}
