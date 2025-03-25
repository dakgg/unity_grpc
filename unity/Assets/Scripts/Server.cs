using UnityEngine;
using Grpc.Net.Client;
using Cysharp.Net.Http;

public class Server : MonoBehaviour
{
    async void Start()
    {
        using var channel = GrpcChannel.ForAddress("http://127.0.0.1:5011", new GrpcChannelOptions()
        {
            HttpHandler = new YetAnotherHttpHandler() { Http2Only = true },
            DisposeHttpClient = true,
        });
        var greeter = new server.Greeter.GreeterClient(channel);
        var result = await greeter.SayHelloAsync(new() { Name = "Test" });
        Debug.Log(result.Message);
    }
}
