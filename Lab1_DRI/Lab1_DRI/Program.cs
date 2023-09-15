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


            Log.Debug("Application stop");
            Log.CloseAndFlush();
        }
    }
}