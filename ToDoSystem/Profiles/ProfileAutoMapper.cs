using AutoMapper;
using ToDoSystem.Dtos.Task;
using ToDoSystem.Models;

namespace ToDoSystem.Profiles;

public class ProfileAutoMapper: Profile
{
    public ProfileAutoMapper()
    {
        CreateMap<TaskCreationDto,TarefaModel>( );
        CreateMap<TarefaModel,TaskPutDto>( );
        CreateMap<TaskPutDto,TarefaModel>( );

    }
}
