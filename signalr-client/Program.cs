using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;

var watch = new Stopwatch();
await using var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7258/simple", opts =>
    {
        opts.HttpMessageHandlerFactory = message =>
        {
            if (message is HttpClientHandler clientHandler)
                clientHandler.ServerCertificateCustomValidationCallback += (sender, cert, chain, err) => { return true; };
            return message;
        };
    })
    .Build();

watch.Start();
await connection.StartAsync();

await foreach (var date in connection.StreamAsync<string>("Streaming"))
{
    Console.WriteLine(date);
}

watch.Stop();

var ts = watch.Elapsed;
Console.WriteLine($"runtime -> {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}");