using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Application.Extentions
{
    public static class LoggerExtention
    {
        public static IDisposable EnrichWithProperty(this ILogger logger, string propertyName, object value)
        {
            return logger.BeginScope(new Dictionary<string, object>(1) { { propertyName, value } });
        }
    }
}
