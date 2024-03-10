using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Commands.Update
{
    internal sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly TaskManagerDbContext _taskManagerDbContext;

        public UpdateTaskCommandHandler(TaskManagerDbContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskUnit = await _taskManagerDbContext.Tasks.FirstAsync(x => x.Id == request.Guid, cancellationToken);

            taskUnit.Name = request.Name;

            await _taskManagerDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
