using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace twittWebApp.Domain
{
  public class TweetRepo : ITweetRepo
  {
    private TwitterCredentials creds = new TwitterCredentials("", "", "", "");
    public IEnumerable<string> Read(string tkey)
    {
      Contract.Requires<ArgumentNullException>(String.IsNullOrEmpty(tkey) == false, "key empty or not valid");
      Contract.Ensures(Contract.Result<IEnumerable<ITweet>>() != null);

      try {
        var searchParameter = new SearchTweetsParameters(tkey) {
          SearchType = SearchResultType.Recent,
          MaximumNumberOfResults = 10,
        };
        return Auth.ExecuteOperationWithCredentials(creds, () =>
        {
          var rl = new List<string>();
          var tweets = Search.SearchTweets(searchParameter);
          foreach(var t in tweets) {
            rl.Add("{" + t.ToString() + "}");
          }
          return rl;
        });
      } catch(Exception) {   /// should catch more detailed exception, but just an example..
        return new List<string>();
      }
    }
    
    public bool Create(string tweetMsg)
    {
      Contract.Requires<ArgumentNullException>(String.IsNullOrEmpty(tweetMsg) == false, "Msg empty or not valid");

      try {
        return Auth.ExecuteOperationWithCredentials(creds, () =>
        {
          var newTweet = Tweet.PublishTweet(tweetMsg); // logging
          //Console.WriteLine("newtweet=" + newTweet.Id);
          return newTweet != null ? true : false;
        });
      } catch(Exception) {   /// should catch more detailed exception, but just an example..
        return false;
      }
    }

    public bool Delete(long tweetId)
    {
      Contract.Requires<ArgumentOutOfRangeException>(tweetId > 0, "Wrong Id");
      try {
        return Auth.ExecuteOperationWithCredentials(creds, () =>
        {
          return Tweet.DestroyTweet(tweetId);
        });
      } catch(Exception) {   /// should catch more detailed exception, but just an example..
        return false;
      }
    }
  }
}