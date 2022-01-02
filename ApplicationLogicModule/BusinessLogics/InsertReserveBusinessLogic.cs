using ApplicationLogicModule.DataAccessLogic;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class InsertReserveBusinessLogic : BusinessLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            CountResultModel resultModel =
                DoDataAccessLogic<InsertReserveDataAccessLogic, CountResultModel, SetTableInputModel<TReserve>>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
