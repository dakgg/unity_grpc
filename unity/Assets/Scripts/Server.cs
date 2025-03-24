using UnityEngine;
using Grpc.Net.Client;
using System;
using Cysharp.Net.Http;

public class Server : MonoBehaviour
{
    const int PORT = 5011;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        using var handler = new YetAnotherHttpHandler();
        using var channel = GrpcChannel.ForAddress($"http://localhost:{PORT}", new GrpcChannelOptions() { HttpHandler = handler });
        var greeter = new server.Greeter.GreeterClient(channel);

        var result = await greeter.SayHelloAsync(new());
        Console.WriteLine(result.Message);
    }
}
