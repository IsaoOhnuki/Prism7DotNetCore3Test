using ModelLibrary.Services;

namespace LogicCommonLibrary.InputModels
{
    public class SetTableInputModel<TTableClass> : DataAccessInputModel
    {
        public SetTableInputModel(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public TTableClass TableClass { get; set; }
    }
}
