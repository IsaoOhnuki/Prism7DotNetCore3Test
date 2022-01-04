﻿using ApplicationLogicModule.CommonLogic;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class CreateReserveBusunessLogic : BusinessLogicBase<CreateReserveResultModel, CreateReserveInputModel>
    {
        protected override CreateReserveResultModel OnExecute(CreateReserveInputModel inputModel)
        {
            Logger.StartMethod();

            CreateReserveResultModel resultModel =
                DoCommonLogic<CreateReserveCommonLogic, CreateReserveResultModel, CreateReserveInputModel>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
