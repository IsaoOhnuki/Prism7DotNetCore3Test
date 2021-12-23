using System.Collections.Generic;

namespace ModelLibrary.ResultModels
{
    public class ResultModelBase
    {
        public bool Result { get; set; }

        public List<MessageModel> Messages { get; set; }
    }
}
