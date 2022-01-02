using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ModelLibrary.Services
{
    public interface IApplicationLogic
    {
        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel);
    }
}
