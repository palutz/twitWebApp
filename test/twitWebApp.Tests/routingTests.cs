using Xunit;
using Nancy;

namespace twittWebApp.Test
{
  // see example explanation on xUnit.net website:
  // https://xunit.github.io/docs/getting-started-dotnet-core.html
  
  // Nancy provide API to easily test the routinh and the API behaviour...
  public class RoutingTestss
  {
    // [Fact]   - not compatibile with dotnet core ...
    // public void HomeShouldWorks()
    // {
    //   // Given
    //   var bootstrapper = new DefaultNancyBootstrapper();
    //   //var browser = new Browser(bootstrapper);

    //   // When
    // //   var result = browser.Get("/", with =>
    // //   {
    // //     with.HttpRequest();
    // //   });

    //   // Then
    //   //Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    //   Assert.OK;
    // }

  }
}
