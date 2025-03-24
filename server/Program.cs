using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Kestrel 서버 설정 추가
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 5011, ListenOptions =>
    {
        ListenOptions.Protocols = HttpProtocols.Http2;
    });

    // 기존의 HTTPS 설정이 있다면 그대로 두거나 다음처럼 추가
    options.Listen(IPAddress.Any, 5012, listenOptions =>
    {
        listenOptions.UseHttps();
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
