using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vLibrary.API.Services
{
    public class LoggerService : ILoggerService
    {
        public string Log(string t)
        {
            return $"Hello {t}";
        }
    }
}
