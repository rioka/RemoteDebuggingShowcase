using Microsoft.Extensions.Configuration;

namespace RemoteDebuggingShowcase.Core
{
  public class Foo
  {
    #region Data

    private readonly IConfiguration _config;
    private readonly Bar _bar;

    #endregion

    #region Constructors

    public Foo(IConfiguration config, Bar bar)
    {
      _config = config;
      _bar = bar;
    }

    #endregion

    #region Apis

    public int Run(string reason)
    {
      var who = Environment.UserName;
      var guess = _bar.Guess(reason);
      Console.WriteLine($"{who}, guess what? {guess}");

      return guess;
    }
    
    #endregion
  }
}