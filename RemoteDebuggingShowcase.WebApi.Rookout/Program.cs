namespace RemoteDebuggingShowcase.WebApi.Rookout
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      await CreateHostBuilder(args)
        .Build()
        .RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host
        .CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => {
          webBuilder.UseStartup<Startup>();
        });
    }
  }
}