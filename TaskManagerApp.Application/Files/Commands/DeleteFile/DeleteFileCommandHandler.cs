using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Application.Extentions;
using TaskManagerApp.Application.Files.Commands.SaveFile;
using TaskManagerApp.Persistence.FileStorage;

namespace TaskManagerApp.Application.Files.Commands.DeleteFile
{
    internal sealed class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly ILogger<SaveFileCommandHandler> _logger;

        public DeleteFileCommandHandler(IFileStorageService fileStorageService, ILogger<SaveFileCommandHandler> logger)
        {
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            using (_logger.EnrichWithProperty("FileStorageId", request.FileStorageId))
            {
                try
                {
                    await _fileStorageService.DeleteFileAsync(request.FileStorageId, cancellationToken);
                }
                catch (Exception ex)
                {
                    throw new CannotDeleteFileException(request.FileStorageId, ex);
                }
            }
        }
    }
}
