using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.LogicBase
{
    public abstract class ApplicationLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        protected TLogicResultModel DoBusinessLogic<TBusinessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TBusinessLogic : BusinessLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            LogStartMethod();

            TBusinessLogic logic = new TBusinessLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = logic.Execute(inputModel);

            LogEndMethod();
            return resultModel;
        }

        protected bool IsBusinessLogic<TBusinessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel, out TLogicResultModel resultModel)
            where TBusinessLogic : BusinessLogicBase<TLogicResultModel, TLogicInputModel>, new()
            where TLogicResultModel : ResultModelBase
        {
            LogStartMethod();

            TBusinessLogic logic = new TBusinessLogic()
            {
                Logger = Logger,
            };
            resultModel = logic.Execute(inputModel);

            LogEndMethod();
            return resultModel.Result;
        }
    }
}
