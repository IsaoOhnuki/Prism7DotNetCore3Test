using ModelLibrary.Services;

namespace LogicCommonLibrary.LogicBase
{
    public class LogicRepositoryBase : LogicBase
    {
        public LogicRepositoryBase(ILogService logger)
        {
            Logger = logger;
        }

        protected TLogicResultModel DoApplicationLogic<TApplicationLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TApplicationLogic : ApplicationLogicBase<TLogicResultModel, TLogicInputModel>, new()
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
    }
}
