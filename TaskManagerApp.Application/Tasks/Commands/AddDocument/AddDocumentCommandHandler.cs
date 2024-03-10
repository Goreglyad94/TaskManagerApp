using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Application.Extentions;
using TaskManagerApp.Application.Files.Commands.SaveFile;
using TaskManagerApp.Domain.Tasks;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Application.Tasks.Commands.AddDocument
{
    public sealed class AddDocumentCommandHandler : IRequestHandler<AddDocumentCommand>
    {
        private readonly IMediator _mediator;
        private readonly TaskManagerDbContext _taskManagerDbContext;
        private readonly ILogger<AddDocumentCommandHandler> _logger;

        public AddDocumentCommandHandler(IMediator mediator, TaskManagerDbContext taskManagerDbContext, ILogger<AddDocumentCommandHandler> logger)
        {
            _mediator = mediator;
            _taskManagerDbContext = taskManagerDbContext;
            _logger = logger;
        }

        public async Task Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {
            using (_logger.EnrichWithProperty("TaskId", request.TaskId))
            using (_logger.EnrichWithProperty("FileName", request.FileName))
            {
                try
                {
                    var taskUnit = await _taskManagerDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.TaskId, cancellationToken);

                    if (taskUnit is null)
                        throw new TaskNotFoundException();

                    var fileStorageResult = await _mediator.Send(new SaveFileCommand(request.FileName, request.FileStream));
                    var documens = new Document(request.FileName, fileStorageResult?.FileStorageId);

                    taskUnit.AddDocument(documens);

                    await _taskManagerDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Ну удалось добавить документ к задаче", ex);
                }
            }
        }
    }
}
