using ApplicationLogicModule.BusinessLogics;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class CreateTableClassApplicationLogic<TTableClass, TInputModel> : ApplicationLogicBase<GetDataResultModel<TTableClass>, TInputModel>
        where TTableClass : class, new()
        where TInputModel : class
    {
        protected override GetDataResultModel<TTableClass> OnExecute(TInputModel inputModel)
        {
            LogStartMethod();

            GetDataResultModel<TTableClass> resultModel =
                DoBusinessLogic<CreateTableClassBusunessLogic<TTableClass, TInputModel>, GetDataResultModel<TTableClass>, TInputModel>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
