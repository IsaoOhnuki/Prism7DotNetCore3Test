﻿using LogicCommonLibrary.DataAccess;
using LogicCommonLibrary.LogicBase;
using LogicCommonLibrary.InputModels;
using ModelLibrary.Models;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApplicationLogicModule.DataAccessLogic
{
    public class UpdateReserveDataAccessLogic : DataAccessLogicBase<CountResultModel, SetTableInputModel<TReserve>>
    {
        protected override CountResultModel OnExecute(SetTableInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            GetCommandQuery<TReserve>.GetInsertQuery(out string query, out List<SqlParameter> sqlParameters);
            NonQueryDataAccess nonQueryDataAccess = new NonQueryDataAccess(inputModel.DatabaseConnection,
                query,
                GetCommandQuery<TReserve>.GetQueryParameter(sqlParameters, CheckModelSchema.GetModelSchema<TReserve>(inputModel.DatabaseConnection.Connection),
                inputModel.TableClass));
            CountResultModel resultModel = new CountResultModel();

            try
            {
                resultModel.Count = nonQueryDataAccess.DoNonQuery(false);
                resultModel.Result = true;
            }
            catch (Exception e)
            {
                resultModel.Result = false;
                resultModel.Messages = new List<MessageModel>()
                {
                    GetDataAccessExceptionMessage(nonQueryDataAccess, e),
                };
            }

            LogEndMethod();
            return resultModel;
        }
    }
}