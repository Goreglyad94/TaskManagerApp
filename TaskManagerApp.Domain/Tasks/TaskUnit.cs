namespace TaskManagerApp.Domain.Tasks
{
    public class TaskUnit
    {
        public TaskUnit() { }

        public TaskUnit(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifyDate { get; set; } = DateTime.UtcNow;
        public TaskStatus TaskStatus { get; set; } = TaskStatus.New;
        public bool IsDeleted { get; set; }

        public List<Document> Documents { get; private set; } = new List<Document>();

        public void AddDocument(Document document)
        {
            if (Documents is null)
                Documents = new List<Document>();

            Documents.Add(document);
        }

        public void DeleteTask()
        {
            IsDeleted = true;
        }

        public void SetResolved()
        {
            SetStatus(TaskStatus.Resolved);
        }

        private void SetStatus(TaskStatus taskStatus)
        {
            TaskStatus = taskStatus;
        }
    }

    public enum TaskStatus
    {
        New,
        Analisis,
        Development,
        Resolved,
        Closed
    }
}
