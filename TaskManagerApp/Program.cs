using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TaskManagerApp.Application;
using TaskManagerApp.Bootstrapping;
using TaskManagerApp.Persistence.Context;
using TaskManagerApp.Persistence.FileStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyTag).Assembly));

builder.Services.AddGridFsBucket(builder.Configuration);

builder.Services.AddDbContext<TaskManagerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskManagerConnectionString"));
});

builder.Services.AddTransient<IFileStorageService, FileStorageService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();