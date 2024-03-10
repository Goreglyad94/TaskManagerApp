using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Domain.Tasks
{
    public class Document
    {
        public Document() { }

        public Document(string name, string fileStorageId)
        {
            Name = name;
            FileStorageId = fileStorageId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileStorageId { get; set; }

        public TaskUnit Task { get; set; }
    }
}
