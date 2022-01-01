namespace ModelLibrary.ActionLogic
{
    public abstract class ApplicationLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        public static TLogicResultModel DoBusinessLogic<TBusinessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TBusinessLogic : BusinessLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            TBusinessLogic logic = new TBusinessLogic();
            TLogicResultModel resultModel = logic.Execute(inputModel);
            return resultModel;
        }
    }
}
