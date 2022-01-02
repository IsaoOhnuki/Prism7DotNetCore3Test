﻿using ModelLibrary.Services;

namespace ModelLibrary.ActionLogic
{
    public abstract class ActionLogicBase<TResultModel, TInputModel>
    {
        public ILogService Logger { get; set; }

        public TResultModel Execute(TInputModel inputModel)
        {
            Logger.StartMethod();

            TResultModel resultModel = OnExecute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }

        protected abstract TResultModel OnExecute(TInputModel inputModel);
    }
}
