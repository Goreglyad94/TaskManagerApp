using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Application.Exceptions;
using TaskManagerApp.Application.Tasks.Commands.AddDocument;
using TaskManagerApp.Application.Tasks.Commands.Create;
using TaskManagerApp.Application.Tasks.Commands.Delete;
using TaskManagerApp.Application.Tasks.Commands.DeleteDocument;
using TaskManagerApp.Application.Tasks.Commands.Update;
using TaskManagerApp.Application.Tasks.Queries.GetById;
using TaskManagerApp.Application.Tasks.Queries.GetWithPagination;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskUnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(GetTask))]
        public async Task<IActionResult> GetTask(Guid guid)
        {
            try
            {
                var unitTask = await _mediator.Send(new GetByIdQuery(guid));

                return Ok(unitTask);
            }
            catch (TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet(nameof(GetTasks))]
        public async Task<IActionResult> GetTasks(int page, int size)
        {
            try
            {
                var unitTask = await _mediator.Send(new GetWithPaginationQuery(page, size));

                return Ok(unitTask);
            }
            catch (TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(string name)
        {
            await _mediator.Send(new CreateTaskCommand(name));

            return Ok();
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteTaskCommand(id));

                return NoContent();
            }
            catch (TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateTaskUnitRequest taskUnitModel)
        {
            try
            {
                await _mediator.Send(new UpdateTaskCommand(taskUnitModel.Id, taskUnitModel.Name));

                return NoContent();
            }
            catch (TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(nameof(UploadFile))]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadRequest model)
        {
            try
            {
                await _mediator.Send(new AddDocumentCommand(model.TaskId, model.File.FileName, model.File.OpenReadStream()));

                return NoContent();
            }
            catch (TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete(nameof(DeleteFile))]
        public async Task<IActionResult> DeleteFile(Guid taskId, string fileSrorageId)
        {
            try
            {
                await _mediator.Send(new DeleteDocumentCommand(taskId, fileSrorageId));

                return NoContent();
            }
            catch (TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
