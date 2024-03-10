using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Application.Extentions;
using TaskManagerApp.Persistence.FileStorage;

namespace TaskManagerApp.Application.Files.Commands.SaveFile
{
    internal sealed class SaveFileCommandHandler : IRequestHandler<SaveFileCommand, SaveFileResult>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly ILogger<SaveFileCommandHandler> _logger;

        public SaveFileCommandHandler(IFileStorageService fileStorageService, ILogger<SaveFileCommandHandler> logger)
        {
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public async Task<SaveFileResult> Handle(SaveFileCommand request, CancellationToken cancellationToken)
        {
            using (_logger.EnrichWithProperty("FileName", request.FileName))
            {
                try
                {
                    var savedFileId = await _fileStorageService.UploadFileAsync(request.FileName, request.FileStream, cancellationToken);
                    return new SaveFileResult(savedFileId.ToString());
                }
                catch (Exception ex)
                {
                    throw new CannotSaveFileException(request.FileName, ex);
                }
            }
        }
    }
}
