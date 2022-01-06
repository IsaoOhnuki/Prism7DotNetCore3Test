using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ModelLibrary.Services
{
    public interface IApplicationLogic
    {
        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel);

        public CountResultModel InsertReserve(SetTableInputModel<TReserve> inputModel);

        public CountResultModel UpdateReserve(SetTableInputModel<TReserve> inputModel);

        public CreateReserveResultModel CreateReserve(CreateReserveInputModel inputModel);
    }
}
