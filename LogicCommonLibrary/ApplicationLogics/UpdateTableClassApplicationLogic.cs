﻿using LogicCommonLibrary.BusinessLogics;
using LogicCommonLibrary.InputModels;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.ResultModels;

namespace LogicCommonLibrary.ApplicationLogics
{
    public class UpdateTableClassApplicationLogic<TTableClass> : ApplicationLogicBase<CountResultModel, TableClassInputModel<TTableClass>>
        where TTableClass : new()
    {
        protected override CountResultModel OnExecute(TableClassInputModel<TTableClass> inputModel)
        {
            LogStartMethod();

            CountResultModel resultModel =
                DoBusinessLogic<UpdateTableClassBusinessLogic<TTableClass>, CountResultModel, TableClassInputModel<TTableClass>>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}