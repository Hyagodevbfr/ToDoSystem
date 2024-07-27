using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToDoSystem.Enums;

namespace ToDoSystem.Web.Models.Task;

public class TaskViewModel
{
    public TaskViewModel()
    {
        CreatedAt = DateTime.UtcNow.ToLocalTime();
        CompletedAt = DateTime.UtcNow.ToLocalTime();
    }
    [Key] public Guid Id { get; set; } = Guid.NewGuid( );
    
    [Required]
    [DisplayName("Tarefa")]
    public string Name { get; set; } = null!;

    [DisplayName("Descrição")]
    public string? Description { get; set; } = string.Empty;

    [Required]
    [DisplayName("Status")]
    public StatusTask Status { get; set; }


    [Required][DefaultValue(false)] public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToLocalTime();
    public DateTime? CompletedAt { get; set; } = null;
}
