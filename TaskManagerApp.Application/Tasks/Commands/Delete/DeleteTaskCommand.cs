using MediatR;

namespace TaskManagerApp.Application.Tasks.Commands.Delete;

public sealed record DeleteTaskCommand(Guid id) : IRequest;
