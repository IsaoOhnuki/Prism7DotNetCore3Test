namespace ModelLibrary.ResultModels
{
    public class GetTableResultModel<TTableClass> : ResultModelBase
    {
        public TTableClass TableClass { get; set; }
    }
}
