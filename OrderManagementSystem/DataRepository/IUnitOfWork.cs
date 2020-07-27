using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        IEnumerable ExecuteReader(string sqlQuery);

        IEnumerable ExecuteReader(string storedProcedureName, SqlParameter[] parameters = null);

        void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null);
    }
}
