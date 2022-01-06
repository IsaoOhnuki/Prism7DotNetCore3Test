using ModelLibrary.ResultModels;
using ModelLibrary.Services;
using System;

namespace LogicCommonLibrary.LogicBase
{
    public class LogicRepositoryBase : LogicBase
    {
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
