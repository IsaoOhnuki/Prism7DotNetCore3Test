using ApplicationLogicModule.BusinessLogics;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class InsertReserveApplicationLogic : ApplicationLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            CountResultModel resultModel =
                DoBusinessLogic<InsertReserveBusinessLogic, CountResultModel, SetTableInputModel<TReserve>>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
