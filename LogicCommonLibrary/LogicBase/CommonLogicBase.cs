using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.LogicBase
{
    public abstract class CommonLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
        where TResultModel : ResultModelBase
    {
    }
}
