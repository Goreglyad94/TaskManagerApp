using MediatR;

namespace TaskManagerApp.Application.Files.Commands.SaveFile
{
    public sealed record SaveFileCommand(string FileName, Stream FileStream) : IRequest<SaveFileResult>;

    public class SaveFileResult
    {
        public SaveFileResult(string fileStorageId)
        {
            FileStorageId = fileStorageId;
        }

        public string FileStorageId { get; set; }
    }
}
