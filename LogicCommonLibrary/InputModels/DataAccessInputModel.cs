using ModelLibrary.InputModel;
using ModelLibrary.Services;

namespace LogicCommonLibrary.InputModels
{
    public class DataAccessInputModel : InputModelBase
    {
        public IDatabaseConnection DatabaseConnection { get; private set; }

        public DataAccessInputModel(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }
    }
}
