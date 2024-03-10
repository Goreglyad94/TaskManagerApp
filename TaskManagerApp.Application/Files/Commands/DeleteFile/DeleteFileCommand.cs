using MediatR;

namespace TaskManagerApp.Application.Files.Commands.DeleteFile
{
    public sealed record DeleteFileCommand(string FileStorageId) : IRequest;
}
