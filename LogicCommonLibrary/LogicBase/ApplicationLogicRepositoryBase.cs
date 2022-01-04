using ModelLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicCommonLibrary.LogicBase
{
    public class ApplicationLogicRepositoryBase
    {
        public ILogService Logger { get; private set; }

        public ApplicationLogicRepositoryBase(ILogService logger)
        {
            Logger = logger;
        }

        protected TLogicResultModel DoApplicationLogic<TApplicationLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TApplicationLogic : ApplicationLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            Logger.StartMethod();

            TApplicationLogic logic = new TApplicationLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = logic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
