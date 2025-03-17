using Grpc.Core;
using UnityEngine;
using Dakg;
using Grpc.Net.Client;

public class Server : MonoBehaviour
{
    const int PORT = 5160;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var channel = GrpcChannel.ForAddress($"localhost:{PORT}");
        // var client = new Dakg.Greeter(channel);
    }
}
