using Nancy;
using System;
using System.Collections.Generic;
using Nancy.ModelBinding;
using Newtonsoft.Json;

using twittWebApp.Domain;


namespace twittWebApp {

  class TweetMessage {
    public string message { get; set; }
  }

  public class TwitterModule : NancyModule {
    private ITweetRepo _repo;
    public TwitterModule(ITweetRepo repo) {
      this._repo = repo;

      Get("/twitter/", _ => {
        return "Twttier APIs ... ";
      });

      Get("/twitter/{name}", parameters =>
      {
        try{
          IEnumerable<string> twitList = this._repo.Read(parameters.name);
          string strRes = "[" + string.Join(", ", twitList) + "]";
          return JsonConvert.SerializeObject(strRes);
        } catch(Exception) {
          return HttpStatusCode.BadRequest;
        }
      });
      
      Post("/twitter/", _ =>
      {
        try {
          var myReq = this.Bind<TweetMessage>();
          return (this._repo.Create(myReq.message) ? HttpStatusCode.Created : HttpStatusCode.ExpectationFailed);
        } catch(Exception) {
          // Console.WriteLine(e.StackTrace);   ... log
          return HttpStatusCode.BadRequest;
        }
      });

      Delete("/twitter/{twitId}", parameters => {
        try {
          var tId = (long) parameters.twitId;
          return (this._repo.Delete(tId) ? HttpStatusCode.OK : HttpStatusCode.EnhanceYourCalm);
        } catch (Exception) {
          return HttpStatusCode.BadRequest;
        }
      });
    }
  }
}