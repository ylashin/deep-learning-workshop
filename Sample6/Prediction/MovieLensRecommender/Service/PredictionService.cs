using MovieLensRecommender.Service.ResponseModel;
using Grpc.Core;
using Newtonsoft.Json;
using System.Configuration;
using Tensorflow;
using Tensorflow.Serving;

namespace MovieLensRecommender.Service
{
    public class Predictor
    {
        public float PredicRating(int userId, int movieId)
        {
            Channel channel = new Channel(ConfigurationManager.AppSettings["ServingRpcChannel"], ChannelCredentials.Insecure);
            try
            {
                var client = new PredictionService.PredictionServiceClient(channel);
                var request = new PredictRequest()
                {
                    ModelSpec = new ModelSpec()
                    {
                        Name = ConfigurationManager.AppSettings["ModelName"],
                        Version = int.Parse(ConfigurationManager.AppSettings["ModelVersion"]),
                        SignatureName = ConfigurationManager.AppSettings["ModelSignature"]
                    }
                };

                var proto1 = GetInput(userId);
                var proto2 = GetInput(movieId);

                request.Inputs.Add("userId", proto1);
                request.Inputs.Add("movieId", proto2);

                var result = client.Predict(request);
                var response = JsonConvert.DeserializeObject<ResponseObject>(result.Outputs.ToString());

                return (float)response.outputs.floatVal[0];
            }
            finally
            {
                channel.ShutdownAsync().Wait();
            }
        }

        private static TensorProto GetInput(int val)
        {
            var proto = new TensorProto
            {
                TensorShape = new TensorShapeProto()
            };
            proto.TensorShape.Dim.Add(new TensorShapeProto.Types.Dim() { Size = 1 });
            proto.TensorShape.Dim.Add(new TensorShapeProto.Types.Dim() { Size = 1 });
            proto.Dtype = DataType.DtInt64;
            proto.Int64Val.Add(val);
            return proto;
        }   
    }
}