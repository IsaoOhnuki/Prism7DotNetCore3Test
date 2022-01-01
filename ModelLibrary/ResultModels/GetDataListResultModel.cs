using System.Collections.Generic;

namespace ModelLibrary.ResultModels
{
    public class GetDataListResultModel<T> : ResultModelBase
    {
        public List<T> DataList { get; set; }
    }
}
