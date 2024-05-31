using Microsoft.Extensions.Configuration;
using RemoteDebuggingShowcase.Core;
using Rook;

namespace RemoteDebuggingShowcase.Rookout
{
  public class Program
  {
    static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<Program>()
        .AddEnvironmentVariables("RDS")
        .Build();
      
      Initialize(config);
      new BasicSample().Run(config);
    }

    #region Internals

    private static void Initialize(IConfigurationRoot config)
    {
      var options = new RookOptions() {
        token = config.GetSection("Rookout:ApiKey")
          .Value,
        labels = new Dictionary<string, string>() {
          ["env"] = "Playground"
        }
      };
      API.Start(options);
    }

    #endregion
  }
}