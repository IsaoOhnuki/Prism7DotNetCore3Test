namespace LogicCommonLibrary.Models
{
    public interface IDataAccess
    {
        public string GetLastQuery();

        public string GetLastQueryParam();
    }
}
