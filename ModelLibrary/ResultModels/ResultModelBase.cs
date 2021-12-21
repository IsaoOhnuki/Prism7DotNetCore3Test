using System.Collections.Generic;

namespace ModelLibrary.ResultModel
{
    public class ResultModelBase
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public List<string> MessageParameter { get; set; }
    }
}
