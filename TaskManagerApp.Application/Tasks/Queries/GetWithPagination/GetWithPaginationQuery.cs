using MediatR;
using TaskManagerApp.Domain.Tasks;

namespace TaskManagerApp.Application.Tasks.Queries.GetWithPagination;

public sealed record GetWithPaginationQuery(int Page, int Size) : IRequest<PagedList<TaskUnit>>;