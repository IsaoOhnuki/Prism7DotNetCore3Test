namespace ModelLibrary.ResultModels
{
    public class GetDataResultModel<TTableClass> : ResultModelBase
    {
        public TTableClass TableClass { get; set; }
    }
}
