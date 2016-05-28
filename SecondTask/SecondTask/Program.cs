using System;
using LoggerLibrary;
using AddressBookLibrary;
namespace SecondTask
{
    class Program
    {
        public Program(ILogger logger)
        {
            _logger = logger;
        }
        private readonly ILogger _logger;
        static void Main()
        {
            Program newProgram = new Program(Logger.Instance);
            newProgram.Test();
         
        }

        public void Test()
        {
            AddressBook addressBook = new AddressBook();
            User user = new User("ivan", "ivanovich", "+3809663089");
            addressBook.UserAdded += AddressBookStateHandler;
            addressBook.UserRemoved += AddressBookStateHandler;
            addressBook.AddUser(user);
            addressBook.AddUser(user);
            addressBook.AddUser(null);
            Console.ReadKey();
        }

        public void AddressBookStateHandler(string type, string log)
        {
            string finalLog = null;

            if (type == "info")
            {
                finalLog = _logger.Info(log);
            }
            if (type == "debug")
            {
                finalLog = _logger.Debug(log);
            }
            if (type == "warning")
            {
                finalLog = _logger.Warning(log);
            }
            if (type == "error")
            {
                finalLog = _logger.Error(log);
            }
            var logger = _logger as Logger;
            if (logger != null)
            {
                logger.WriteToFile(finalLog, "log1.txt");
                logger.WriteToConsole(finalLog);
                //(_logger as Logger).WriteToDB(finalLog, "logdb");
            }

        }
    }
}
