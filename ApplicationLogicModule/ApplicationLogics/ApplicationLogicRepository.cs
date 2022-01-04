using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Services;
using LogicCommonLibrary.LogicBase;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class ApplicationLogicRepository : ApplicationLogicRepositoryBase, IApplicationLogic
    {
        public IDatabaseConnection DatabaseConnection { get; set; }

        public ApplicationLogicRepository(ILogService logger, IDatabaseConnection databaseConnection)
            : base(logger)
        {
            DatabaseConnection = databaseConnection;
        }

        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel)
        {
            Logger.StartMethod();

            LogicCommonLibrary.InputModels.GetPeriodReserveInputModel dbInputModel =
                new LogicCommonLibrary.InputModels.GetPeriodReserveInputModel()
                {
                    DatabaseConnection = DatabaseConnection,
                    ReserveStart = inputModel.ReserveStart,
                    ReserveEnd = inputModel.ReserveEnd,
                };
            GetDataListResultModel<TReserve> resultModel =
                DoApplicationLogic<GetPeriodReserveApplicationLogic, GetDataListResultModel<TReserve>,
                    LogicCommonLibrary.InputModels.GetPeriodReserveInputModel>(dbInputModel);

            Logger.EndMethod();
            return resultModel;
        }

        public CountResultModel InsertReserve(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            LogicCommonLibrary.InputModels.SetTableInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>()
                {
                    DatabaseConnection = DatabaseConnection,
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel =
                DoApplicationLogic<InsertReserveApplicationLogic, CountResultModel,
                    LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>>(dbInputModel);

            Logger.EndMethod();
            return resultModel;
        }

        public CountResultModel SetReserve(SetTableInputModel<TReserve> inputModel)
        {
            Logger.StartMethod();

            LogicCommonLibrary.InputModels.SetTableInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>()
                {
                    DatabaseConnection = DatabaseConnection,
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel =
                DoApplicationLogic<SetReserveApplicationLogic, CountResultModel,
                    LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>>(dbInputModel);

            Logger.EndMethod();
            return resultModel;
        }

        public CreateReserveResultModel CreateReserve(CreateReserveInputModel inputModel)
        {
            Logger.StartMethod();

            CreateReserveResultModel resultModel =
                DoApplicationLogic<CreateReserveApplicationLogic, CreateReserveResultModel, CreateReserveInputModel>(inputModel);

            Logger.EndMethod();
            return resultModel;
        }
    }
}
