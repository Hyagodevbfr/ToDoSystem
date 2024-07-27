using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoSystem.Models;

namespace ToDoSystem.Data.Map;

public class TaskMap: IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
