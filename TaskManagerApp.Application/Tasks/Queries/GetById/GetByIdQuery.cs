using MediatR;
using TaskManagerApp.Domain.Tasks;

namespace TaskManagerApp.Application.Tasks.Queries.GetById;

public sealed record GetByIdQuery(Guid id) : IRequest<TaskUnit>;