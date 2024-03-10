using MediatR;

namespace TaskManagerApp.Application.Tasks.Commands.DeleteDocument;

public sealed record DeleteDocumentCommand(Guid TaskId, string FileStorageId) : IRequest;