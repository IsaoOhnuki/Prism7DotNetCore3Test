using ModelLibrary.InputModel;

namespace ModelLibrary.InputModels
{
    public class SetDataInputModel<TTableClass> : InputModelBase
    {
        public TTableClass TableClass { get; set; }
    }
}
