﻿using LogicCommonLibrary.CommonLogic;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.BusinessLogics
{
    public class CreateTableClassBusunessLogic<TTableClass, TInputModel> : BusinessLogicBase<GetDataResultModel<TTableClass>, TInputModel>
        where TTableClass : class
        where TInputModel : class
    {
        protected override GetDataResultModel<TTableClass> OnExecute(TInputModel inputModel)
        {
            LogStartMethod();

            GetDataResultModel<TTableClass> resultModel =
                DoCommonLogic<CreateDataCommonLogic<TTableClass, TInputModel>, GetDataResultModel<TTableClass>, TInputModel>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
