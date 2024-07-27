using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoSystem.Data;
using ToDoSystem.Dtos.Task;
using ToDoSystem.Enums;
using ToDoSystem.Interfaces.TaskInterface;
using ToDoSystem.Models;

namespace ToDoSystem.Services.Task;

public class TaskService: ITask
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public TaskService(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<TarefaModel> PostTask(TaskCreationDto taskCreationDto)
    {
        var task = _mapper.Map<TarefaModel>(taskCreationDto);

        if(task.Status == Enums.StatusTask.Concluded)
        {
            task.IsCompleted = true;
            task.CompletedAt = DateTime.UtcNow;
        }
        if(task.IsCompleted == true) 
        {
            task.Status = StatusTask.Concluded;
            task.CompletedAt = DateTime.UtcNow;
        }

        await _appDbContext.Tarefas!.AddAsync(task);
        await _appDbContext.SaveChangesAsync( );

        return task;
    }
    public async Task<TarefaModel?> PutTask([FromBody]TaskPutDto taskPutDto, Guid id)
    {
        var task = await _appDbContext.Tarefas!.FirstOrDefaultAsync(x => x.Id == id);
        if(task == null) 
        {
            return null;
        }

        //_mapper.Map(taskPutDto, task);

        task.Name = taskPutDto.Name;
        task.Description = taskPutDto.Description;
        task.Status = taskPutDto.Status;

        if(task.Status == Enums.StatusTask.Concluded)
        {
        task.IsCompleted = true;
        task.CompletedAt = DateTime.UtcNow;
        }
        else
        {
            task.IsCompleted = false;
            task.CompletedAt = null;
        }

        _appDbContext.Tarefas!.Update(task);
        await _appDbContext.SaveChangesAsync();
        return task;
    }

    public async Task<TarefaModel?> GetTaskId(Guid id)
    {
        var task = await _appDbContext.Tarefas!.FirstOrDefaultAsync(x => x.Id == id);

        if(task == null)
            return null;
        else
            return task;
    }

    public async Task<List<TarefaModel>> GetTasks()
    {
        var task = await _appDbContext.Tarefas!.ToListAsync();
        
        return task;
    }


    public async Task<bool> DeleteTask(Guid id)
    {
        TarefaModel? task = await GetTaskId(id);
        
        _appDbContext.Tarefas!.Remove(task!);
        await _appDbContext.SaveChangesAsync();

        return true;


    }
}
