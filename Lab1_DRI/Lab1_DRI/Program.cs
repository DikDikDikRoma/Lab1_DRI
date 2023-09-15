using Serilog;


namespace Lab1_DRI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("")
                .CreateLogger();

            Log.Debug("Application start");

            // Run
            Operation.GetSum("1", "2", "3");
            Operation.GetSum("4", "4", "7");
            Operation.GetSum("15", "15", "15");
            Operation.GetSum("3", "4", "5");
            Operation.GetSum("1", "-2", "3");
            Operation.GetSum("1s", "2d", "3");

            Log.Debug("Application stop");
            Log.CloseAndFlush();
        }
    }
}