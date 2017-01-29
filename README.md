# Twitter client

## a simple web app to try:

- .Net Core and web app
- an OWIN Web Fx (NancyFx in this case)
- now C#, "soon" F#

Prerequisites:
- dotnet Core 1.0.0-preview2-003156

To run it: 
- Create your own Twitter app and add the keys to the TwittRepo (I know, I could hae put them on a config file, but not a big fan on keeping sensible data there and also just want something simple)
- from src/twitWebApp run: dotnet restore, dotnet run
- and the app will acccept incoming request from localhost:5000


Happened to be a twitter client... Found a proper, nice, lib to use wit the Twitter API also compatible with .Net Core.

Created the structure and some code for testing...
At the moment the code doesn't need so much testing thanks also to the use of Contracts (and, honestly, didn't have so much time). Just created a dummy repo but not so useful like this.
Also found some trouble on testing with Nancy since som parts are not implemented yet (Browser and so on).
