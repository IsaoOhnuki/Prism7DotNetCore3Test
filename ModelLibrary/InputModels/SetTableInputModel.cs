using ModelLibrary.InputModel;

namespace ModelLibrary.InputModels
{
    public class SetTableInputModel<TTableClass> : InputModelBase
    {
        public TTableClass TableClass { get; set; }
    }
}
