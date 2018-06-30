using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheApp
{
    public class ServingModel
    {
        public float PredictIdentity(float attribute1, float attribute2)
        {
            Channel channel = new Channel("localhost:7000", ChannelCredentials.Insecure);
            try
            {
                var client = new PredictionService.PredictionServiceClient(channel);
                var request = new PredictRequest()
                {
                    ModelSpec = new ModelSpec()
                    {
                        Name = "ex2",
                        Version = 1,
                        SignatureName = "Predict"
                    }
                };


                var proto = new TensorProto
                {
                    TensorShape = new TensorShapeProto(),
                    Dtype = DataType.DtFloat
                };

                // one sample in batch, first dimension is always number of samples submitted for prediction
                proto.TensorShape.Dim.Add(new TensorShapeProto.Types.Dim() { Size = 1 });
                proto.TensorShape.Dim.Add(new TensorShapeProto.Types.Dim() { Size = 2 });

                proto.FloatVal.Add(attribute1);
                proto.FloatVal.Add(attribute2);

                request.Inputs.Add("inputs", proto);
                var result = client.Predict(request);
                var response = JsonConvert.DeserializeObject<ServingResponse>(result.Outputs.ToString());

                return (float)response.outputs.floatVal[0];
            }
            finally
            {
                channel.ShutdownAsync().Wait();
            }
        }
    }
}
