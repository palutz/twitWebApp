using Tweetinvi.Models;
using System.Collections.Generic;

namespace twittWebApp.Domain {
  public interface ITweetRepo {
    IEnumerable<string> Read(string key);
    bool Create(string tweetMsg);
    bool Delete(long tweetId);
  }
}
