using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.LogicBase
{
    public abstract class BusinessLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        protected TLogicResultModel DoCommonLogic<TCommonLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TCommonLogic : CommonLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            LogStartMethod();

            TCommonLogic logic = new TCommonLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = logic.Execute(inputModel);

            LogEndMethod();
            return resultModel;
        }

        protected bool IsCommonLogic<TCommonLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel, out TLogicResultModel resultModel)
            where TCommonLogic : CommonLogicBase<TLogicResultModel, TLogicInputModel>, new()
            where TLogicResultModel : ResultModelBase
        {
            LogStartMethod();

            resultModel = DoCommonLogic<TCommonLogic, TLogicResultModel, TLogicInputModel>(inputModel);

            LogEndMethod();
            return resultModel.Result;
        }

        protected TLogicResultModel DoDataAccessLogic<TDataAccessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel)
            where TDataAccessLogic : DataAccessLogicBase<TLogicResultModel, TLogicInputModel>, new()
        {
            LogStartMethod();

            TDataAccessLogic dataAccess = new TDataAccessLogic()
            {
                Logger = Logger,
            };
            TLogicResultModel resultModel = dataAccess.Execute(inputModel);

            LogEndMethod();
            return resultModel;
        }

        protected bool IsDataAccessLogic<TDataAccessLogic, TLogicResultModel, TLogicInputModel>(TLogicInputModel inputModel, out TLogicResultModel resultModel)
            where TDataAccessLogic : DataAccessLogicBase<TLogicResultModel, TLogicInputModel>, new()
            where TLogicResultModel : ResultModelBase
        {
            LogStartMethod();

            resultModel = DoDataAccessLogic<TDataAccessLogic, TLogicResultModel, TLogicInputModel>(inputModel);

            LogEndMethod();
            return resultModel.Result;
        }
    }
}
