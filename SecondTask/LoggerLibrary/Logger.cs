using System;

namespace LoggerLibrary
{
    public class Logger : LogWriter
    {
        private static readonly Lazy<Logger> Lazy =
        new Lazy<Logger>(() => new Logger());
        public static Logger Instance { get { return Lazy.Value; } }

        private Logger()
        {
        }
        private string Generatelog(string type, string message, string stackTrace = null)
        {
            return string.Format("Type:" + type + " Date:" + DateTime.Now.ToShortDateString() + " Time:" + DateTime.Now.ToShortTimeString() + " Message: " + message);
        }

        public override string Info(string message)
        {
            string type = "Info";
            return Generatelog(type, message);
        }

        public override string  Debug(string message)
        {
            string type = "Debug";
            return Generatelog(type, message);
        }

        public override string Warning(string message)
        {
            string type = "Warning";
            return Generatelog(type, message);
        }

        public override string Error(string message)
        {
            string type = "Error";
            return Generatelog(type, message);
        }

    }
}
