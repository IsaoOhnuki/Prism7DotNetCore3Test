using ModelLibrary.Services;

namespace LogicCommonLibrary.InputModels
{
    public class GetDataInputModel<TTable> : DataAccessInputModel
    {
        public GetDataInputModel(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public TTable TableClass { get; set; }
    }
}
