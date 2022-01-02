using ApplicationLogicModule.Properties;
using LogicCommonLibrary.DataAccess;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationLogicModule.DataAccessLogic
{
    public class GetPeriodReserveDataAccessLogic : DataAccessLogicBase<GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>
    {
        protected override GetDataListResultModel<TReserve> OnExecute(GetPeriodReserveInputModel inputModel)
        {
            Logger.StartMethod();

            string query = SqlResources.GetPeriodReserve;

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new QueryParameter("@ReserveStart ", SqlDbType.DateTime2, inputModel.ReserveStart),
                new QueryParameter("@ReserveEnd", SqlDbType.DateTime2, inputModel.ReserveEnd),
            };

            QueryDataAccess<TReserve> queryDataAccess = new QueryDataAccess<TReserve>(inputModel.DatabaseConnection, query, sqlParameters);
            GetDataListResultModel<TReserve> resultModel = new GetDataListResultModel<TReserve>();

            try
            {
                resultModel.DataList = queryDataAccess.DoQuery();
                resultModel.Result = true;
            }
            catch (Exception e)
            {
                resultModel.Messages = new List<MessageModel>()
                {
                    GetDataAccessExceptionMessage(queryDataAccess, e)
                };
            }

            Logger.EndMethod();
            return resultModel;
        }
    }
}
