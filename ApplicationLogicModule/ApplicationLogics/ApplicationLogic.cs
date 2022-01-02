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

        public CountResultModel InsertReserve(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            InsertReserveApplicationLogic applicationLogic =
                new InsertReserveApplicationLogic()
                {
                    Logger = Logger,
                };
            CountResultModel resultModel = applicationLogic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }

        public CountResultModel SetReserve(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            SetReserveApplicationLogic applicationLogic =
                new SetReserveApplicationLogic()
                {
                    Logger = Logger,
                };
            CountResultModel resultModel = applicationLogic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }

        public GetTableResultModel<TReserve> GetReserve(GetDataInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            GetReserveApplicationLogic applicationLogic =
                new GetReserveApplicationLogic()
                {
                    Logger = Logger,
                };
            GetTableResultModel<TReserve> resultModel = applicationLogic.Execute(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
