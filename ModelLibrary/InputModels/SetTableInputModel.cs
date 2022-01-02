using ModelLibrary.InputModel;

namespace ModelLibrary.InputModels
{
    public class SetTableInputModel<TTableClass> : DataAccessInputModel
    {
        public TTableClass TableClass { get; set; }
    }
}
