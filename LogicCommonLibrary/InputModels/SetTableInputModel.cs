namespace LogicCommonLibrary.InputModels
{
    public class SetTableInputModel<TTableClass> : DataAccessInputModel
    {
        public TTableClass TableClass { get; set; }
    }
}
