using ApplicationLogicModule.CommonLogic;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;

namespace ApplicationLogicModule.BusinessLogics
{
    public class CreateReserveBusunessLogic : BusinessLogicBase<CreateReserveResultModel, CreateReserveInputModel>
    {
        protected override CreateReserveResultModel OnExecute(CreateReserveInputModel inputModel)
        {
            LogStartMethod();

            CreateReserveResultModel resultModel =
                DoCommonLogic<CreateReserveCommonLogic, CreateReserveResultModel, CreateReserveInputModel>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
