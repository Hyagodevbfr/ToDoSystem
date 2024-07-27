using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToDoSystem.Enums;

namespace ToDoSystem.Dtos.Task;

public class TaskCreationDto
{
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; } = string.Empty;
    [Required] public StatusTask Status { get; set; }
    [Required][DefaultValue(false)] public bool IsCompleted { get; set; } = false;
}
