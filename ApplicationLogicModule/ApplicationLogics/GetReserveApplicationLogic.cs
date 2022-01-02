using ApplicationLogicModule.BusinessLogics;
using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class GetReserveApplicationLogic : ApplicationLogicBase<GetTableResultModel<TReserve>, GetDataInputModel<TReserve>>
    {
        protected override GetTableResultModel<TReserve> OnExecute(GetDataInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            GetTableResultModel<TReserve> resultModel =
                DoBusinessLogic<GetReserveBusinessLogic, GetTableResultModel<TReserve>, GetDataInputModel<TReserve>>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
