import asyncio
import grpc
from concurrent import futures
import redhvid.flight_video_distributor_pb2 as bufs
import redhvid.flight_video_distributor_pb2_grpc as rpc

from flight_video_distributor_servicer import FlightVideoDistributorServicer


async def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    rpc.add_FlightVideoDistributorServicer_to_server(
        FlightVideoDistributorServicer(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    await test()
    server.wait_for_termination()


async def test():
    print('Hello')
    channel = grpc.insecure_channel('localhost:50051')
    stub = rpc.FlightVideoDistributorStub(channel)
    resp = stub.Echo(bufs.FlightVideoMessage(message="Hello world!"))
    print(resp.message)


try:
    asyncio.run(serve())
except KeyboardInterrupt:
    print("Terminated.")
