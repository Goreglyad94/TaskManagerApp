using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskManagerApp.Domain.Tasks;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Commands.Create
{
    internal sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
    {
        private readonly TaskManagerDbContext _taskManagerDbContext;

        public CreateTaskCommandHandler(TaskManagerDbContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var taskUnit = new TaskUnit(Guid.NewGuid(), request.Name);
                await _taskManagerDbContext.Tasks.AddAsync(taskUnit, cancellationToken);

                await _taskManagerDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
