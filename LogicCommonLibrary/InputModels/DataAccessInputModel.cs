using ModelLibrary.InputModel;
using ModelLibrary.Services;

namespace LogicCommonLibrary.InputModels
{
    public class DataAccessInputModel : InputModelBase
    {
        public IDatabaseConnection DatabaseConnection { get; set; }
    }
}
