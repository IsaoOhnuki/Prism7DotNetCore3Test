using ApplicationLogicModule.DataAccessLogic;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class GetReserveBusinessLogic : BusinessLogicBase<GetTableResultModel<TReserve>, GetDataInputModel<TReserve>>
    {
        protected override GetTableResultModel<TReserve> OnExecute(GetDataInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            GetTableResultModel<TReserve> resultModel =
                DoDataAccessLogic<GetReserveDataAccessLogic, GetTableResultModel<TReserve>, GetDataInputModel<TReserve>>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
