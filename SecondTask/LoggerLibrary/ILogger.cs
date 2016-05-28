using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary
{
  public interface ILogger
    {
        string Info(string message);
        string Debug(string message);
        string Warning(string message);
        string Error(string message);
    }
}
