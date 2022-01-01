namespace ModelLibrary.ActionLogic
{
    public abstract class BusinessLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        public static TLogicResultModel DoCommonLogic<TCommonLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TCommonLogic : CommonLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            TCommonLogic logic = new TCommonLogic();
            TLogicResultModel resultModel = logic.Execute(inputModel);
            return resultModel;
        }

        public static TLogicResultModel DoDataAccessLogic<TDataAccessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TDataAccessLogic : DataAccessLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            TDataAccessLogic dataAccess = new TDataAccessLogic();
            TLogicResultModel resultModel = dataAccess.Execute(inputModel);
            return resultModel;
        }
    }
}
