using LogicCommonLibrary.DataAccess;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationLogicModule.DataAccessLogic
{
    public class GetPeriodReserveDataAccessLogic : DataAccessLogicBase<GetPeriodReserveResultModel, GetPeriodReserveInputModel>
    {
        protected override GetPeriodReserveResultModel OnExecute(GetPeriodReserveInputModel inputModel)
        {
            string query = "SELECT * FROM TReserve TR WHERE TR.ReserveEnd >= @ReserveStart AND TR.ReserveStart <= @ReserveEnd;";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new QueryParameter("@ReserveStart ", SqlDbType.DateTime2, inputModel.ReserveStart),
                new QueryParameter("@ReserveEnd", SqlDbType.DateTime2, inputModel.ReserveEnd),
            };
            QueryDataAccess<TReserve> queryDataAccess = new QueryDataAccess<TReserve>(null, query, sqlParameters);
            GetPeriodReserveResultModel resultModel = new GetPeriodReserveResultModel()
            {
                DataList = queryDataAccess.DoQuery(),
            };
            return resultModel;
        }
    }
}
