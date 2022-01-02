﻿using ApplicationLogicModule.DataAccessLogic;
using LogicCommonLibrary.LogicBase;
using LogicCommonLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class GetPeriodReserveBusinessLogic : BusinessLogicBase<GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>
    {
        protected override GetDataListResultModel<TReserve> OnExecute(GetPeriodReserveInputModel inputModel)
        {
            Logger.StartMethod();

            GetDataListResultModel<TReserve> resultModel =
                DoDataAccessLogic<GetPeriodReserveDataAccessLogic, GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
