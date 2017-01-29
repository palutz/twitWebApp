using Nancy;


namespace twittWebApp
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get("/", _ =>
      {
        return "Hello World";
      }); 
    }
  }
}
