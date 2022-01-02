namespace LogicCommonLibrary.LogicBase
{
    public abstract class BusinessLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        protected TLogicResultModel DoCommonLogic<TCommonLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TCommonLogic : CommonLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            Logger.StartMethod();

            TCommonLogic logic = new TCommonLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = logic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }

        protected TLogicResultModel DoDataAccessLogic<TDataAccessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TDataAccessLogic : DataAccessLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            Logger.StartMethod();

            TDataAccessLogic dataAccess = new TDataAccessLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = dataAccess.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
