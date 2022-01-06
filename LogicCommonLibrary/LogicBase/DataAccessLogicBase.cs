using LogicCommonLibrary.Models;
using ModelLibrary.Models;
using ModelLibrary.ResultModels;
using System;

namespace LogicCommonLibrary.LogicBase
{
    public abstract class DataAccessLogicBase<TResultModel, TInputModel> : ActionLogicBase<TResultModel, TInputModel>
        where TResultModel : ResultModelBase
    {
        protected MessageModel GetDataAccessExceptionMessage(IDataAccess dataAccess, Exception exception)
        {
            LogStartMethod();

            MessageModel result = new MessageModel(
                message: "data access inner exception of '" + GetType().Name + "'\r\n{0}\r\n{1}",
                parameter: new string[] { dataAccess.GetLastQuery(), dataAccess.GetLastQueryParam() },
                exception: exception);

            LogEndMethod();
            return result;
        }
    }
}
