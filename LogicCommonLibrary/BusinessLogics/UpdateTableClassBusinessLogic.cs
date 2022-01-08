using LogicCommonLibrary.DataAccessLogic;
using LogicCommonLibrary.InputModels;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.BusinessLogics
{
    public class UpdateTableClassBusinessLogic<TTableClass> : BusinessLogicBase<CountResultModel, TableClassInputModel<TTableClass>>
        where TTableClass : new()
    {
        protected override CountResultModel OnExecute(TableClassInputModel<TTableClass> inputModel)
        {
            LogStartMethod();

            CountResultModel resultModel =
                DoDataAccessLogic<UpdateTableClassDataAccessLogic<TTableClass>, CountResultModel, TableClassInputModel<TTableClass>>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
