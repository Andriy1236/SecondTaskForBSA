using System.Data.Entity;

namespace LoggerLibrary
{
    class LogContext : DbContext
    {
        public LogContext()
        { }

        public LogContext(string dbNameOrConnection)
        : base(dbNameOrConnection)
        { }

        public DbSet<LogModel> LogModels { get; set; }

    }
}
