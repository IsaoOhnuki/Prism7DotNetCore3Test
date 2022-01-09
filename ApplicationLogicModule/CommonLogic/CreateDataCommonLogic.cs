using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using System;

namespace ApplicationLogicModule.CommonLogic
{
    public class CreateDataCommonLogic<TTableClass, TInputModel> : CommonLogicBase<GetDataResultModel<TTableClass>, TInputModel>
        where TTableClass : class
        where TInputModel : class
    {
        protected override GetDataResultModel<TTableClass> OnExecute(TInputModel inputModel)
        {
            LogStartMethod();

            GetDataResultModel<TTableClass> resultModel = new GetDataResultModel<TTableClass>();

            if (typeof(TTableClass) == typeof(TReserve))
            {
                resultModel.TableClass = GetReserve(inputModel as CreateReserveInputModel) as TTableClass;
            }
            else
            {
                throw new NotImplementedException();
            }

            LogEndMethod();
            return resultModel;
        }

        protected TReserve GetReserve(CreateReserveInputModel inputModel)
        {
            return new TReserve()
            {
                ReserveStart = inputModel.StartDateTime,
                ReserveEnd = inputModel.EndDateTime,
                BlockStart = inputModel.StartDateTime.AddHours(-1),
                BlockEnd = inputModel.EndDateTime.AddHours(1),
                ReserveMemo1 = "Reserve",
            };
        }
    }
}
