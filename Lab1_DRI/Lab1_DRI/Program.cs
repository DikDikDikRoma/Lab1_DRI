using Serilog;


namespace Lab1_DRI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("")
                .CreateLogger();

            Log.Debug("Application start");

            // Run
            Operation.GetTypeAndCoord("5", "4", "3");
            Operation.GetTypeAndCoord("4", "3", "5");
            Operation.GetTypeAndCoord("15", "15", "15");
            Operation.GetTypeAndCoord("3", "4", "5");
            Operation.GetTypeAndCoord("1", "-2", "3");
            Operation.GetTypeAndCoord("1s", "2d", "3");

            Log.Debug("Application stop");
            Log.CloseAndFlush();
        }
    }
}