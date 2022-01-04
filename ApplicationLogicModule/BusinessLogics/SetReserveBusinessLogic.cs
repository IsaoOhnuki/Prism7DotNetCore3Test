using ApplicationLogicModule.DataAccessLogic;
using LogicCommonLibrary.LogicBase;
using LogicCommonLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class SetReserveBusinessLogic : BusinessLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            CountResultModel resultModel =
                DoDataAccessLogic<SetReserveDataAccessLogic, CountResultModel, SetTableInputModel<TReserve>>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
