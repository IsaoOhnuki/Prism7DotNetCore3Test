using ApplicationLogicModule.DataAccessLogic;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class GetPeriodReserveBusinessLogic : BusinessLogicBase<GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>
    {
        protected override GetDataListResultModel<TReserve> OnExecute(GetPeriodReserveInputModel inputModel)
        {
            GetDataListResultModel<TReserve> resultModel =
                DoDataAccessLogic<GetPeriodReserveDataAccessLogic, GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>(inputModel);
            return resultModel;
        }
    }
}
