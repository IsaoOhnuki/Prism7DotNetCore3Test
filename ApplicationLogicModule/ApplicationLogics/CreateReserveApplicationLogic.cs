using ApplicationLogicModule.BusinessLogics;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class CreateReserveApplicationLogic : ApplicationLogicBase<CreateReserveResultModel, CreateReserveInputModel>
    {
        protected override CreateReserveResultModel OnExecute(CreateReserveInputModel inputModel)
        {
            LogStartMethod();

            CreateReserveResultModel resultModel =
                DoBusinessLogic<CreateReserveBusunessLogic, CreateReserveResultModel, CreateReserveInputModel>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
