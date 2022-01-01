using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.ActionLogic
{
    public static class ActionLogicInvoker<TLogic, TResultModel, TInputModel>
        where TLogic : ActionLogicBase<TResultModel, TInputModel>, new()
    {
        public static TResultModel Invoke(TInputModel inputModel)
        {
            TLogic logic = new TLogic();
            TResultModel resultModel = logic.Execute(inputModel);
            return resultModel;
        }
    }
}
