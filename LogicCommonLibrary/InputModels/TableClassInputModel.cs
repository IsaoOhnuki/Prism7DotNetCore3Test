using ModelLibrary.Services;

namespace LogicCommonLibrary.InputModels
{
    public class TableClassInputModel<TTableClass> : DataAccessInputModel
    {
        public TableClassInputModel(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public TTableClass TableClass { get; set; }
    }
}
