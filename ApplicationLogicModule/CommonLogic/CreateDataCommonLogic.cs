﻿using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.Models;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System.Collections.Generic;

namespace ApplicationLogicModule.CommonLogic
{
    public class CreateDataCommonLogic<TTableClass, TInputModel> : CommonLogicBase<GetDataResultModel<TTableClass>, TInputModel>
        where TTableClass : class, new()
        where TInputModel : class
    {
        protected override GetDataResultModel<TTableClass> OnExecute(TInputModel inputModel)
        {
            LogStartMethod();

            GetDataResultModel<TTableClass> resultModel = new GetDataResultModel<TTableClass>();

            if (typeof(TTableClass) == typeof(TReserve))
            {
                resultModel.TableClass = GetReserve(inputModel as CreateReserveInputModel) as TTableClass;
                resultModel.Result = true;
            }
            else
            {
                resultModel.Result = false;
                resultModel.Messages = new List<MessageModel>()
                {
                    new MessageModel("'{0}' is not implemented create code.",
                        new List<string>()
                        {
                            new TTableClass().GetType().Name
                        }.ToArray())
                };
            }

            LogEndMethod();
            return resultModel;
        }

        protected TReserve GetReserve(CreateReserveInputModel inputModel)
        {
            return new TReserve()
            {
                State = inputModel.ReserveState,
                ReserveStart = inputModel.StartDateTime,
                ReserveEnd = inputModel.EndDateTime,
                BlockStart = inputModel.StartDateTime.AddHours(-1),
                BlockEnd = inputModel.EndDateTime.AddHours(1),
                ReserveMemo1 = "Reserve",
            };
        }
    }
}