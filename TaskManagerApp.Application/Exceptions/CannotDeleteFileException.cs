using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Application.Exceptions
{
    internal class CannotDeleteFileException : Exception
    {
        public CannotDeleteFileException(string fileId, Exception ex) : base($"Ошибка удаления файла {fileId} в файловое хранилище", ex)
        {

        }
    }
}
