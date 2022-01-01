namespace ModelLibrary.ActionLogic
{
    public abstract class ActionLogicBase<TResultModel, TInputModel>
    {
        public TResultModel Execute(TInputModel inputModel)
        {
            TResultModel resultModel = OnExecute(inputModel);
            return resultModel;
        }

        protected abstract TResultModel OnExecute(TInputModel inputModel);
    }
}
