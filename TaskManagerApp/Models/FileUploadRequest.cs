namespace TaskManagerApp.Models
{
    public class FileUploadRequest
    {
        public Guid TaskId { get; set; }
        public IFormFile? File { get; set; }
    }
}
