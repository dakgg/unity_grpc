# unity_grpc



protoc -I=Protos \
  --csharp_out=../client/Generated \
  --grpc_out=../client/Generated \
  --plugin=protoc-gen-grpc=$(which grpc_csharp_plugin) \
  Protos/greet.proto
