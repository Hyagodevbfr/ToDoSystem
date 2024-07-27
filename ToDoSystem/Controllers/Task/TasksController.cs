using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoSystem.Dtos.Task;
using ToDoSystem.Interfaces.TaskInterface;
using ToDoSystem.Models;

namespace ToDoSystem.Controllers.Task;
[Route("api/[controller]/[action]")]
[ApiController]
public class TasksController: ControllerBase
{
    private readonly ITask _task;
    private readonly IMapper _mapper;

    public TasksController(ITask taskInterface,IMapper mapper)
    {
        _task = taskInterface;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<List<TarefaModel>>> GetTasks()
    {
        try
        {
            List<TarefaModel> tasks = await _task.GetTasks( );
            return Ok(tasks);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaModel>> GetTaskId(Guid id)
    {
        try
        {
            var tasks = await _task.GetTaskId(id);
            return Ok(tasks);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<TarefaModel>> PostTask([FromBody] TaskCreationDto taskCreationDto)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _task.PostTask(taskCreationDto);
            task.CompletedAt = null;

            return Created($"/tasks/{taskCreationDto}",taskCreationDto);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("editar/{id}")]
    public async Task<ActionResult<TarefaModel>> PutTask([FromBody] TaskPutDto taskPutDto,Guid id)
    {
        try
        {
            var task = await _task.PutTask(taskPutDto, id);
            

            return Ok(taskPutDto);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<TarefaModel>> DeleteTask(Guid id)
    {
        var deletedTask = await _task.DeleteTask(id);
        return Ok(deletedTask);
    }
}
