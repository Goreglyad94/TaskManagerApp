using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Application.Extentions;
using TaskManagerApp.Application.Files.Commands.DeleteFile;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Commands.DeleteDocument
{
    internal sealed class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IMediator _mediator;
        private readonly TaskManagerDbContext _taskManagerDbContext;
        private readonly ILogger<DeleteDocumentCommandHandler> _logger;

        public DeleteDocumentCommandHandler(IMediator mediator, TaskManagerDbContext taskManagerDbContext, ILogger<DeleteDocumentCommandHandler> logger)
        {
            _mediator = mediator;
            _taskManagerDbContext = taskManagerDbContext;
            _logger = logger;
        }

        public async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            using (_logger.EnrichWithProperty("TaskId", request.TaskId))
            using (_logger.EnrichWithProperty("FileStorageId", request.FileStorageId))
            {
                try
                {
                    var taskUnit = await _taskManagerDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.TaskId);

                    if (taskUnit is null)
                        throw new TaskNotFoundException();

                    var docuement = taskUnit.Documents.FirstOrDefault(x => x.FileStorageId == request.FileStorageId);
                    taskUnit.Documents.Remove(docuement);

                    await _taskManagerDbContext.SaveChangesAsync();

                    await _mediator.Send(new DeleteFileCommand(docuement.FileStorageId));
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Ошибка удаления файла");
                }
            }  
        }
    }
}
