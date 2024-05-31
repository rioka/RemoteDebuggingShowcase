using Microsoft.Extensions.Configuration;
using NerdVision;
using RemoteDebuggingShowcase.Core;

namespace RemoteDebuggingShowcase.NerdVision
{
  class Program
  {
    static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<Program>()
        .Build();

      Initialize(config);
      new BasicSample().Run(config);
    }

    #region Internals

    private static void Initialize(IConfiguration config)
    {
      NV.Start(config.GetSection("NerdVision:ApiKey").Value);
    }

    #endregion
  }
}