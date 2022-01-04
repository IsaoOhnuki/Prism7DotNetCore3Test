using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.CommonLogic
{
    public class CreateReserveCommonLogic : CommonLogicBase<CreateReserveResultModel, CreateReserveInputModel>
    {
        protected override CreateReserveResultModel OnExecute(CreateReserveInputModel inputModel)
        {
            LogStartMethod();

            CreateReserveResultModel resultModel = new CreateReserveResultModel()
            {
                Reserve = new TReserve()
                {
                    ReserveStart = inputModel.StartDateTime,
                    ReserveEnd = inputModel.EndDateTime,
                    BlockStart = inputModel.StartDateTime.AddHours(-1),
                    BlockEnd = inputModel.EndDateTime.AddHours(1),
                },
            };

            LogEndMethod();
            return resultModel;
        }
    }
}
