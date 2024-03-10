using MediatR;

namespace TaskManagerApp.Application.Tasks.Commands.Update;

public sealed record UpdateTaskCommand(Guid Guid, string Name) : IRequest;

