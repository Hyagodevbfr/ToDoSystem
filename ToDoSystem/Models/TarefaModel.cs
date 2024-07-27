using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ToDoSystem.Enums;

namespace ToDoSystem.Models;

public class TarefaModel
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; } = string.Empty;
    [Required] public StatusTask Status { get; set; }
    [Required] [DefaultValue(false)] public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt {  get; set; } = null;

}
