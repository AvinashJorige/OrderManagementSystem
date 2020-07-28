using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DataRepository
{
    /// <summary>
    /// This is the wrapper around repositiry. This creates the instance of context and returns the repository called.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> Repository<T>() where T : class;
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        IEnumerable ExecuteReader<T>(string sqlQuery) where T : class;

        IEnumerable ExecuteReader<T>(string storedProcedureName, SqlParameter[] parameters = null) where T : class;

        void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null);
    }
}
