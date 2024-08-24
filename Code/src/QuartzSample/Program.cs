namespace QuartzSample;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Title = AppDomain.CurrentDomain.FriendlyName;

            var builder = CreateHostBuilder(args).Build();

            builder.Run();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostingContext, services) =>
        {
            services.ConfigQuartz(hostingContext.Configuration);

        });
}