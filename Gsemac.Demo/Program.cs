// See https://aka.ms/new-console-template for more information
using Gsemac.IO.Logging;
using Gsemac.Net;
using Gsemac.Net.Cloudflare.FlareSolverr;
using Gsemac.Polyfills.Microsoft.Extensions.DependencyInjection;
using System.Text;

Console.WriteLine("Hello, World!");

// Fix Bug:No data is available for encoding 437. 
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

static ServiceProvider CreateServiceProvider()
{

    return new ServiceCollection()
        .AddSingleton<ILogger, ConsoleLogger>()
        .AddSingleton<IWebClientFactory, WebClientFactory>()
        .AddSingleton<IFlareSolverrService, FlareSolverrService>()
        .AddSingleton<WebRequestHandler, FlareSolverrChallengeHandler>()
        .BuildServiceProvider();

}

using (ServiceProvider serviceProvider = CreateServiceProvider())
{

    IWebClientFactory webClientFactory = serviceProvider.GetRequiredService<IWebClientFactory>();

    using IWebClient webClient = webClientFactory.Create();
    Console.WriteLine(webClient.DownloadString("https://www.m884d.com/"));

}

Console.Read();