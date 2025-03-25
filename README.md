# unity_grpc

### Install Nesssary Package
``` bash
brew install grpc
brew install protobuf
``` 


### How to use
``` bash 
protoc -I=Protos \
      --csharp_out=${PATH} \
      --grpc_out=${PATH} \
      --plugin=protoc-gen-grpc=$(which grpc_csharp_plugin) \
      Protos/greet.proto
```