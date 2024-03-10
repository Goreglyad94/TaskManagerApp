namespace TaskManagerApp.Application.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() : base("Задача не найдена") { }
    }
}
