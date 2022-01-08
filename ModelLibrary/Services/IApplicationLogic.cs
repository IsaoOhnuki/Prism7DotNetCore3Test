using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ModelLibrary.Services
{
    public interface IApplicationLogic
    {
        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel);

        public CountResultModel InsertReserve(SetDataInputModel<TReserve> inputModel);

        public CountResultModel UpdateReserve(SetDataInputModel<TReserve> inputModel);

        public GetDataResultModel<TReserve> CreateReserve(CreateReserveInputModel inputModel);
    }
}
