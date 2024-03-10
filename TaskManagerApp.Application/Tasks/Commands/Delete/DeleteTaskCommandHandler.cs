using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Commands.Delete
{
    internal sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly TaskManagerDbContext _taskManagerDbContext;

        public DeleteTaskCommandHandler(TaskManagerDbContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskUnit = await _taskManagerDbContext.Tasks.FirstAsync(cancellationToken);

            if (taskUnit is null)
                throw new TaskNotFoundException();

            taskUnit.DeleteTask();

            await _taskManagerDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
