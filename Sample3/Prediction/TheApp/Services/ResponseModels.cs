using System.Collections.Generic;

namespace TheApp
{
    public class Dim
    {
        public string size { get; set; }
    }

    public class TensorShape
    {
        public List<Dim> dim { get; set; }
    }

    public class Outputs
    {
        public string dtype { get; set; }
        public TensorShape tensorShape { get; set; }
        public List<double> floatVal { get; set; }
    }

    public class ResponseObject
    {
        public Outputs outputs { get; set; }
    }
}