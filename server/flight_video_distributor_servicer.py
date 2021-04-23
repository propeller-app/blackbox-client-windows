import redhvid.flight_video_distributor_pb2 as bufs
import redhvid.flight_video_distributor_pb2_grpc as rpc
import grpc


class FlightVideoDistributorServicer(rpc.FlightVideoDistributorServicer):

    def echo(self, request: bufs.FlightVideoMessage, context: grpc.ServicerContext) -> bufs.FlightVideoMessage:
        print("Echo receive()")
        return request

    Echo = echo
