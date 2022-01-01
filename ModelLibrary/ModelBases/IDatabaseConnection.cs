using System.Data;
using System.Data.SqlClient;

namespace ModelLibrary.ModelBases
{
    public interface IDatabaseConnection
    {
        public SqlConnection Connection { get; }

        public SqlCredential Credential { get; }

        public SqlTransaction Transaction { get; }

        public ConnectionState State { get; }

        public void Open(bool transaction);

        public void Commit();

        public void Rollback();

        public void Close();
    }
}
