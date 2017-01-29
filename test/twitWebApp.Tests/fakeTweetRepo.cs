using Xunit;
using System.Collections.Generic;

using twittWebApp.Domain;

namespace twittWebApp.Test {
  public class FakeTweetRepo : ITweetRepo {
    private List<string> tRepo = new List<string>();
    public IEnumerable<string> Read(string tkey)
    {
      var rl = new List<string>();
      foreach(var s in tRepo) {
        if(s.Contains(tkey))
          rl.Add(s);
      }
      return rl;
    }
    
    public bool Create(string tweetMsg)
    {
      tRepo.Add(tweetMsg);
      return true;
    }

    public bool Delete(long tweetId)
    {
      if(tRepo.Count > tweetId) {
        tRepo.RemoveAt((int)tweetId);

        return true;
      } else
        return false;
    }

  }

}