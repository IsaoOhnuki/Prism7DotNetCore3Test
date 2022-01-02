using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Services;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class ApplicationLogic : IApplicationLogic
    {
        public ILogService Logger { get; set; }

        public ApplicationLogic(ILogService logger)
        {
            Logger = logger;
        }

        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel)
        {
            Logger.StartMethod();

            GetPeriodReserveApplicationLogic applicationLogic =
                new GetPeriodReserveApplicationLogic()
                {
                    Logger = Logger,
                };
            GetDataListResultModel<TReserve> resultModel = applicationLogic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
