using ToDoSystem.Dtos.Task;
using ToDoSystem.Models;

namespace ToDoSystem.Interfaces.TaskInterface;

public interface ITask
{
    Task<List<TarefaModel>> GetTasks();
    Task<TarefaModel?> GetTaskId(Guid id);
    Task<TarefaModel> PostTask(TaskCreationDto taskCreationDto);
    Task<TarefaModel?> PutTask(TaskPutDto taskPutDto, Guid id);
    Task<bool> DeleteTask(Guid id);

}
