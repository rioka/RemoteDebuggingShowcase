using System;

namespace RemoteDebuggingShowcase.Core
{
  public class Bar
  {
    public Guid Id { get; }

    #region Constructors

    public Bar()
    {
      Id = Guid.NewGuid();
    }

    #endregion

    #region Apis

    public int Guess(string target)
    {
      return target switch {
        "life" => 42,
        _ => DateTime.UtcNow.Millisecond
      };
    }    

    #endregion
  }
}