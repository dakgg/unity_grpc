using Grpc.Net.Client;
using server;

using var channel = GrpcChannel.ForAddress("https://localhost:5207");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = "gRPC!" });
Console.WriteLine("응답: " + reply.Message);