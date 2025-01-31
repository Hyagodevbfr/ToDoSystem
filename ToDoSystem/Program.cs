using Microsoft.EntityFrameworkCore;
using ToDoSystem.Data;
using ToDoSystem.Interfaces.TaskInterface;
using ToDoSystem.Services.Task;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer( );
builder.Services.AddSwaggerGen( );

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ITask, TaskService>( );


builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection"));
});

var app = builder.Build( );

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment( ))
{
    app.UseSwagger( );
    app.UseSwaggerUI( );
}

app.UseHttpsRedirection( );

app.UseAuthorization( );

app.MapControllers( );

app.Run( );
