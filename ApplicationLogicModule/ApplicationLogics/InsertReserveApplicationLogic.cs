using ApplicationLogicModule.BusinessLogics;
using LogicCommonLibrary.LogicBase;
using LogicCommonLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class InsertReserveApplicationLogic : ApplicationLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            CountResultModel resultModel =
                DoBusinessLogic<InsertReserveBusinessLogic, CountResultModel, SetTableInputModel<TReserve>>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
