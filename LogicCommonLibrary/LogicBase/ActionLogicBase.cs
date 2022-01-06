using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.LogicBase
{
    public abstract class ActionLogicBase<TResultModel, TInputModel> : LogicBase
        where TResultModel : ResultModelBase
    {
        public TResultModel Execute(TInputModel inputModel)
        {
            LogStartMethod();

            TResultModel resultModel = OnExecute(inputModel);

            LogEndMethod();
            return resultModel;
        }

        public bool IsExecuteResult(TInputModel inputModel, out TResultModel resultModel)
        {
            LogStartMethod();

            resultModel = OnExecute(inputModel);

            LogEndMethod();
            return resultModel.Result;
        }

        protected abstract TResultModel OnExecute(TInputModel inputModel);
    }
}
