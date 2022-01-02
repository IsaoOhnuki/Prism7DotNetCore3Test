using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Services;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class ApplicationLogic : IApplicationLogic
    {
        public ILogService Logger { get; set; }

        public IDatabaseConnection DatabaseConnection { get; set; }

        public ApplicationLogic(ILogService logger, IDatabaseConnection databaseConnection)
        {
            Logger = logger;
            DatabaseConnection = databaseConnection;
        }

        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel)
        {
            Logger.StartMethod();

            GetPeriodReserveApplicationLogic applicationLogic =
                new GetPeriodReserveApplicationLogic()
                {
                    Logger = Logger,
                };

            LogicCommonLibrary.InputModels.GetPeriodReserveInputModel dbInputModel =
                new LogicCommonLibrary.InputModels.GetPeriodReserveInputModel()
                {
                    DatabaseConnection = DatabaseConnection,
                    ReserveStart = inputModel.ReserveStart,
                    ReserveEnd = inputModel.ReserveEnd,
                };
            GetDataListResultModel<TReserve> resultModel = applicationLogic.Execute(dbInputModel);

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

            LogicCommonLibrary.InputModels.SetTableInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>()
                {
                    DatabaseConnection = DatabaseConnection,
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel = applicationLogic.Execute(dbInputModel);

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

            LogicCommonLibrary.InputModels.SetTableInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>()
                {
                    DatabaseConnection = DatabaseConnection,
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel = applicationLogic.Execute(dbInputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
