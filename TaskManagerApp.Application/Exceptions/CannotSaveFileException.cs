using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Application.Exceptions
{
    internal sealed class CannotSaveFileException : Exception
    {
        public CannotSaveFileException(string fileName, Exception ex) : base($"Ошибка сохранения файла {fileName} в файловое хранилище", ex)
        {
            
        }
    }
}
