## redhvid

An application built for distributing flight footage to customers for Redhill Aviation Flight Centre.

The repository is split up into three projects, client, proto and server:

- [client](/tree/main/client) - The windows desktop client, automagically recognises a storage device and begins transcode and upload (transplode?!) to the gRPC server.
- [proto](/tree/main/proto) - Project containing protobuf files for common client-server communication contracts. 
- [server](/tree/main/server) - The Python gRPC server responsible for notifying customers of completed uploads.