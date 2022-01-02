namespace LogicCommonLibrary.LogicBase
{
    public abstract class ApplicationLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        protected TLogicResultModel DoBusinessLogic<TBusinessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TBusinessLogic : BusinessLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            Logger.StartMethod();

            TBusinessLogic logic = new TBusinessLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = logic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
