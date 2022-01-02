using ApplicationLogicModule.BusinessLogics;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class SetReserveApplicationLogic : ApplicationLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            CountResultModel resultModel =
                DoBusinessLogic<SetReserveBusinessLogic, CountResultModel, SetTableInputModel<TReserve>>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
