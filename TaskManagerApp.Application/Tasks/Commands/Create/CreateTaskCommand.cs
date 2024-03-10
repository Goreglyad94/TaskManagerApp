using MediatR;

namespace TaskManagerApp.Application.Tasks.Commands.Create;

public sealed record CreateTaskCommand(string Name) : IRequest;

