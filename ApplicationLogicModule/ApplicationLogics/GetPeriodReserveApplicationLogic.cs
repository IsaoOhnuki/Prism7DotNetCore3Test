using ApplicationLogicModule.BusinessLogics;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class GetPeriodReserveApplicationLogic : ApplicationLogicBase<GetPeriodReserveResultModel, GetPeriodReserveInputModel>
    {
        protected override GetPeriodReserveResultModel OnExecute(GetPeriodReserveInputModel inputModel)
        {
            GetPeriodReserveResultModel resultModel = ActionLogicInvoker<
                GetPeriodReserveBusinessLogic, GetPeriodReserveResultModel, GetPeriodReserveInputModel>.
                    Invoke(inputModel);
            return resultModel;
        }
    }
}
