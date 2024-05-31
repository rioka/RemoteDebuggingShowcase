using Microsoft.Extensions.Configuration;

namespace RemoteDebuggingShowcase.Core
{
  public class BasicSample
  {
    public void Run(IConfiguration config)
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
  }
}