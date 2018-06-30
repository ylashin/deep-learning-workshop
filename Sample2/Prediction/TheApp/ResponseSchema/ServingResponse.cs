using System.Collections.Generic;

namespace TheApp.ResponseSchema
{
    public class Dim
    {
        public int size { get; set; }
    }

    public class TensorShape
    {
        public IList<Dim> dim { get; set; }
    }

    public class Outputs
    {
        public string dtype { get; set; }
        public TensorShape tensorShape { get; set; }
        public IList<double> floatVal { get; set; }
    }

    public class ServingResponse
    {
        public Outputs outputs { get; set; }
    }
}
