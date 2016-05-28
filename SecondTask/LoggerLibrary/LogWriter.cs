using System;
using System.IO;

namespace LoggerLibrary
{
    public abstract class LogWriter : ILogger
    {

        public abstract string Info(string message);
        public abstract string Debug(string message);
        public abstract string Warning(string message);
        public abstract string Error(string message);


        public virtual void WriteToConsole(string log)
        {
            Console.WriteLine(log);
        }

        public virtual void WriteToFile(string log, string path)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(log);
            streamWriter.Flush();
            streamWriter.Close();
            /* public override void Close()            метод  Close сам визиває Dispose
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }*/
        }

        //public virtual void WriteToDB(string log, string DbName)
        //{

        //   // string path = string.Format(@"Server=.\SQLEXPRESS;Database=" + DbName + ";Trusted_Connection=true");
        //    using (LogContext context = new LogContext()) // для бд using
        //    {
        //        context.LogModels.Add(new LogModel() { log = log });
        //        context.SaveChanges();
        //    }

        //}
    }
}
