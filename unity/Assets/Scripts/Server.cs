using UnityEngine;
using Grpc.Net.Client;
using System;

public class Server : MonoBehaviour
{
    const int PORT = 5207;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        var channel = GrpcChannel.ForAddress($"https://localhost:{PORT}");
        var client = new server.Greeter.GreeterClient(channel);

        var result = await client.SayHelloAsync(new());
        Console.WriteLine(result.Message);
    }
}
