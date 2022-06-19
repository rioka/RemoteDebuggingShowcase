using System;
using System.Collections.Generic;
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
        .Build();
      
      Initialize(config);

      Run(config);
    }

    #region Internals

    private static void Run(IConfigurationRoot config)
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