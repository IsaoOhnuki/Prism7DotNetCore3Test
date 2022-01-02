namespace LogicCommonLibrary.InputModels
{
    public class GetDataInputModel<TTable> : DataAccessInputModel
    {
        public TTable TableClass { get; set; }
    }
}
