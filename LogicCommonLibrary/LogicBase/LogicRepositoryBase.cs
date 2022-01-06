using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.LogicBase
{
    public class LogicRepositoryBase : LogicBase
    {
        protected TLogicResultModel DoApplicationLogic<TApplicationLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TApplicationLogic : ApplicationLogicBase<TLogicResultModel, TLogicInputModel>, new()
            where TLogicResultModel : ResultModelBase
        {
            LogStartMethod();

            TApplicationLogic logic = new TApplicationLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = logic.Execute(inputModel);

            LogEndMethod();
            return resultModel;
        }

        protected bool IsApplicationLogic<TApplicationLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel, out TLogicResultModel resultModel)
            where TApplicationLogic : ApplicationLogicBase<TLogicResultModel, TLogicInputModel>, new()
            where TLogicResultModel : ResultModelBase
        {
            LogStartMethod();

            TApplicationLogic logic = new TApplicationLogic()
            {
                Logger = Logger,
            };
            bool result = logic.IsExecuteResult(inputModel, out resultModel);

            LogEndMethod();
            return result;
        }
    }
}
