using ModelLibrary.ActionLogic;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogicModule.DataAccessLogic
{
    public class GetReserveDataAccessLogic : DataAccessLogicBase<GetTableResultModel<TReserve>, GetDataInputModel<TReserve>>
    {
        protected override GetTableResultModel<TReserve> OnExecute(GetDataInputModel<TReserve> inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
