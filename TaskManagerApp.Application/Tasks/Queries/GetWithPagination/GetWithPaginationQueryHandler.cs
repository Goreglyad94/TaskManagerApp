using MediatR;
using TaskManagerApp.Application.Extentions;
using TaskManagerApp.Domain.Tasks;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Queries.GetWithPagination
{
    internal sealed class GetWithPaginationQueryHandler : IRequestHandler<GetWithPaginationQuery, PagedList<TaskUnit>>
    {
        private readonly TaskManagerDbContext _context;

        public GetWithPaginationQueryHandler(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<TaskUnit>> Handle(GetWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks.ToPagedListAsync(request.Page, request.Size);
        }
    }
}
