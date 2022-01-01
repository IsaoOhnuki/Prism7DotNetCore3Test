using ModelLibrary.Models;
using System;

namespace ModelLibrary.ActionLogic
{
    public abstract class DataAccessLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
    {
        public MessageModel GetDataAccessExceptionMessage(IDataAccess dataAccess, Exception exception)
        {
            return new MessageModel(
                message: "data access inner exception of '" + GetType().Name + "'\r\n{0}\r\n{1}",
                parameter: new string[] { dataAccess.GetLastQuery(), dataAccess.GetLastQueryParam() },
                exception: exception);
        }
    }
}
