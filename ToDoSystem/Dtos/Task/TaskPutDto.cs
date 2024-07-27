using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToDoSystem.Enums;
using System.Text.Json.Serialization;

namespace ToDoSystem.Dtos.Task;

public class TaskPutDto
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; } = string.Empty;
    [Required] public StatusTask Status { get; set; }
    //[Required] public bool IsCompleted { get; set; } = false;
    
}
