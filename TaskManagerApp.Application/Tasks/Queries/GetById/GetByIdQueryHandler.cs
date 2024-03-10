using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Domain.Tasks;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Queries.GetById
{
    internal sealed class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, TaskUnit>
    {
        private readonly TaskManagerDbContext _context;

        public GetByIdQueryHandler(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<TaskUnit> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            //TODO: добавить пагинацию

            var unitTask = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);

            if (unitTask is null)
                throw new TaskNotFoundException();

            return unitTask;
        }
    }
}
