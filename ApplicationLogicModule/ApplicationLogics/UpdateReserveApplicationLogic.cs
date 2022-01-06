using ApplicationLogicModule.BusinessLogics;
using LogicCommonLibrary.LogicBase;
using LogicCommonLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class UpdateReserveApplicationLogic : ApplicationLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            CountResultModel resultModel =
                DoBusinessLogic<UpdateReserveBusinessLogic, CountResultModel, SetTableInputModel<TReserve>>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
