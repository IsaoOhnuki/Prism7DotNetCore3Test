using ModelLibrary.Services;
using System.Runtime.CompilerServices;

namespace LogicCommonLibrary.LogicBase
{
    public abstract class ActionLogicBase<TResultModel, TInputModel> : LogicBase
    {
        public TResultModel Execute(TInputModel inputModel)
        {
            LogStartMethod();

            TResultModel resultModel = OnExecute(inputModel);

            LogEndMethod();
            return resultModel;
        }

        protected abstract TResultModel OnExecute(TInputModel inputModel);
    }
}
