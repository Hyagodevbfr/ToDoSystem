using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToDoSystem.Enums;

namespace ToDoSystem.Dtos.Task;

public class TaskResponseDto
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; } = string.Empty;
    [Required] public StatusTask Status { get; set; }
    [Required][DefaultValue(false)] public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; } = null;
}
