﻿using ApplicationLogicModule.BusinessLogics;
using LogicCommonLibrary.LogicBase;
using LogicCommonLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class GetPeriodReserveApplicationLogic : ApplicationLogicBase<GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>
    {
        protected override GetDataListResultModel<TReserve> OnExecute(GetPeriodReserveInputModel inputModel)
        {
            Logger.StartMethod();

            GetDataListResultModel<TReserve> resultModel =
                DoBusinessLogic<GetPeriodReserveBusinessLogic, GetDataListResultModel<TReserve>, GetPeriodReserveInputModel>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
