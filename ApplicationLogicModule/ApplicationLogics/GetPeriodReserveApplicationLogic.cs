using ApplicationLogicModule.BusinessLogics;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class GetPeriodReserveApplicationLogic : ApplicationLogicBase<GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>
    {
        protected override GetDataListResultModel<TReserve> OnExecute(GetPeriodReserveInputModel inputModel)
        {
            GetDataListResultModel<TReserve> resultModel =
                DoBusinessLogic<GetPeriodReserveBusinessLogic, GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>(inputModel);
            return resultModel;
        }
    }
}
