using System;
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
      Run(config);
    }

    #region Internals

    private static void Run(IConfiguration config)
    {
      Console.WriteLine("Hi there!");

      var foo = new Foo(config, new Bar());
      while (true)
      {
        Console.Write("What do you want an answer for? (Enter 'Q' to quit): ");
        var reason = Console.ReadLine();

        if (reason.Equals("Q", StringComparison.OrdinalIgnoreCase))
        {
          break;
        }

        Console.WriteLine($"Mhh... maybe the answer to {reason} is {foo.Run(reason)}");
      }
    }

    private static void Initialize(IConfiguration config)
    {
      NV.Start(config.GetSection("NerdVision:ApiKey").Value);
    }

    #endregion
  }
}