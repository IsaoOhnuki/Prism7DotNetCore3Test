using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Services;
using LogicCommonLibrary.LogicBase;

namespace ApplicationLogicModule.ApplicationLogics
{
    public class ApplicationLogicRepository : LogicRepositoryBase, IApplicationLogic
    {
        public IDatabaseConnection DatabaseConnection { get; set; }

        public ApplicationLogicRepository(ILogService logger, IDatabaseConnection databaseConnection)
        {
            Logger = logger;
            DatabaseConnection = databaseConnection;
        }

        public GetDataListResultModel<TReserve> GetPeriodReserve(GetPeriodReserveInputModel inputModel)
        {
            LogStartMethod();

            LogicCommonLibrary.InputModels.GetPeriodReserveInputModel dbInputModel =
                new LogicCommonLibrary.InputModels.GetPeriodReserveInputModel(DatabaseConnection)
                {
                    ReserveStart = inputModel.ReserveStart,
                    ReserveEnd = inputModel.ReserveEnd,
                };
            GetDataListResultModel<TReserve> resultModel =
                DoApplicationLogic<GetPeriodReserveApplicationLogic, GetDataListResultModel<TReserve>,
                    LogicCommonLibrary.InputModels.GetPeriodReserveInputModel>(dbInputModel);

            LogEndMethod();
            return resultModel;
        }

        public CountResultModel InsertReserve(SetTableInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            LogicCommonLibrary.InputModels.SetTableInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>(DatabaseConnection)
                {
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel =
                DoApplicationLogic<InsertReserveApplicationLogic, CountResultModel,
                    LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>>(dbInputModel);

            LogEndMethod();
            return resultModel;
        }

        public CountResultModel SetReserve(SetTableInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            LogicCommonLibrary.InputModels.SetTableInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>(DatabaseConnection)
                {
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel =
                DoApplicationLogic<SetReserveApplicationLogic, CountResultModel,
                    LogicCommonLibrary.InputModels.SetTableInputModel<TReserve>>(dbInputModel);

            LogEndMethod();
            return resultModel;
        }

        public CreateReserveResultModel CreateReserve(CreateReserveInputModel inputModel)
        {
            LogStartMethod();

            CreateReserveResultModel resultModel =
                DoApplicationLogic<CreateReserveApplicationLogic, CreateReserveResultModel, CreateReserveInputModel>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
