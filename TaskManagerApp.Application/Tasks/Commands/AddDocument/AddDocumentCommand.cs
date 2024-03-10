using MediatR;

namespace TaskManagerApp.Application.Tasks.Commands.AddDocument
{
    public sealed record AddDocumentCommand(Guid TaskId, string FileName, Stream FileStream) : IRequest;
}
