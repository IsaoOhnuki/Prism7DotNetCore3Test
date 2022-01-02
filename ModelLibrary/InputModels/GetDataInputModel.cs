using ModelLibrary.InputModel;

namespace ModelLibrary.InputModels
{
    public class GetDataInputModel<TTable> : InputModelBase
    {
        public TTable TableClass { get; set; }
    }
}
