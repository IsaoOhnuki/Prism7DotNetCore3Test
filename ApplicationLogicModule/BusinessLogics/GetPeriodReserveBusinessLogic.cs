using ApplicationLogicModule.DataAccessLogic;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class GetPeriodReserveBusinessLogic : BusinessLogicBase<GetPeriodReserveResultModel, GetPeriodReserveInputModel>
    {
        protected override GetPeriodReserveResultModel OnExecute(GetPeriodReserveInputModel inputModel)
        {
            GetPeriodReserveResultModel resultModel = ActionLogicInvoker<
                GetPeriodReserveDataAccessLogic, GetPeriodReserveResultModel, GetPeriodReserveInputModel>.
                    Invoke(inputModel);
            return resultModel;
        }
    }
}
