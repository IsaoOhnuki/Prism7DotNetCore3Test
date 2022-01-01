using ModelLibrary.InputModel;
using ModelLibrary.ModelBases;

namespace ModelLibrary.InputModels
{
    public class DataAccessInputModel : InputModelBase
    {
        public IDatabaseConnection DatabaseConnection { get; set; }
    }
}
