using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.ActionLogic
{
    public abstract class ActionLogicBase<TResultModel, TInputModel>
    {
        public TResultModel Execute(TInputModel inputModel)
        {
            return OnExecute(inputModel);
        }

        protected abstract TResultModel OnExecute(TInputModel inputModel);
    }
}
