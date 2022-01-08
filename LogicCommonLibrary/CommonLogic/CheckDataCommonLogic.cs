using LogicCommonLibrary.InputModels;
using LogicCommonLibrary.LogicBase;
using ModelLibrary.ResultModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LogicCommonLibrary.CommonLogic
{
    public class CheckDataCommonLogic<TData> : CommonLogicBase<ResultModelBase, TableClassInputModel<TData>>
        where TData : new()
    {
        protected override ResultModelBase OnExecute(TableClassInputModel<TData> inputModel)
        {
            ResultModelBase resultModel = new ResultModelBase();
            TData data = new TData();

            foreach (var prop in data.GetType().GetProperties())
            {
                foreach (var attr in prop.GetCustomAttributes(typeof(ValidationAttribute)))
                {
                    ValidationAttribute validation = attr as ValidationAttribute;
                    //validation.IsValid()
                }
            }
            return resultModel;
        }
    }
}
