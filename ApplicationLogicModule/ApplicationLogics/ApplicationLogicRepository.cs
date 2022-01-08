using LogicCommonLibrary.ApplicationLogics;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using ModelLibrary.Services;

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

        public CountResultModel InsertReserve(SetDataInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            LogicCommonLibrary.InputModels.TableClassInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.TableClassInputModel<TReserve>(DatabaseConnection)
                {
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel =
                DoApplicationLogic<InsertTableClassApplicationLogic<TReserve>, CountResultModel,
                    LogicCommonLibrary.InputModels.TableClassInputModel<TReserve>>(dbInputModel);

            LogEndMethod();
            return resultModel;
        }

        public CountResultModel UpdateReserve(SetDataInputModel<TReserve> inputModel)
        {
            LogStartMethod();

            LogicCommonLibrary.InputModels.TableClassInputModel<TReserve> dbInputModel =
                new LogicCommonLibrary.InputModels.TableClassInputModel<TReserve>(DatabaseConnection)
                {
                    TableClass = inputModel.TableClass,
                };
            CountResultModel resultModel =
                DoApplicationLogic<UpdateTableClassApplicationLogic<TReserve>, CountResultModel,
                    LogicCommonLibrary.InputModels.TableClassInputModel<TReserve>>(dbInputModel);

            LogEndMethod();
            return resultModel;
        }

        public GetDataResultModel<TReserve> CreateReserve(CreateReserveInputModel inputModel)
        {
            LogStartMethod();

            GetDataResultModel<TReserve> resultModel =
                DoApplicationLogic<CreateTableClassApplicationLogic<TReserve, CreateReserveInputModel>, GetDataResultModel<TReserve>, CreateReserveInputModel>(inputModel);

            LogEndMethod();
            return resultModel;
        }
    }
}
