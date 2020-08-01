using System;
using System.Collections.Generic;
using Domain;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections;

namespace DataRepository
{
    /// <summary>
    /// This is the wrapper around repositiry. This creates the instance of context and returns the repository called.
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed;
        private Dictionary<string, object> repositories;
        private GenericRepositoryDBContext context;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            context = new GenericRepositoryDBContext();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Releases unmanaged and – optionally – managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }
        public IEnumerable ExecuteReader<T>(string sqlQuery) where T : class
        {
            try
            {
                var result = context.Database.SqlQuery<T>(sqlQuery);
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable ExecuteReader<T>(string storedProcedureName, SqlParameter[] parameters = null) where T : class
        {
            if (parameters != null && parameters.Any())
            {
                var parameterBuilder = new StringBuilder();
                parameterBuilder.Append(string.Format("EXEC {0} ", storedProcedureName));

                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].SqlDbType == SqlDbType.VarChar
                        || parameters[i].SqlDbType == SqlDbType.NVarChar
                        || parameters[i].SqlDbType == SqlDbType.Char
                        || parameters[i].SqlDbType == SqlDbType.NChar
                        || parameters[i].SqlDbType == SqlDbType.Text
                        || parameters[i].SqlDbType == SqlDbType.NText)
                    {
                        parameterBuilder.Append(string.Format("{0}='{1}'", parameters[i].ParameterName,
                            string.IsNullOrEmpty(parameters[i].Value.ToString())
                            ? string.Empty : parameters[i].Value.ToString()));
                    }
                    else if (parameters[i].SqlDbType == SqlDbType.BigInt
                       || parameters[i].SqlDbType == SqlDbType.Int
                       || parameters[i].SqlDbType == SqlDbType.TinyInt
                       || parameters[i].SqlDbType == SqlDbType.Decimal
                       || parameters[i].SqlDbType == SqlDbType.Float
                       || parameters[i].SqlDbType == SqlDbType.Money
                       || parameters[i].SqlDbType == SqlDbType.SmallInt
                       || parameters[i].SqlDbType == SqlDbType.SmallMoney)
                    {
                        parameterBuilder.Append(string.Format("{0}={1}", parameters[i].ParameterName
                            , parameters[i].Value));
                    }
                    else if (parameters[i].SqlDbType == SqlDbType.Bit)
                    {
                        parameterBuilder.Append(string.Format("{0}={1}", parameters[i].ParameterName,
                            Convert.ToBoolean(parameters[i].Value)));
                    }

                    if (i < parameters.Length - 1)
                    {
                        parameterBuilder.Append(",");
                    }
                }

                var query = parameterBuilder.ToString();
                var result = context.Database.SqlQuery<T>(query);
                return result.ToList();
            }
            else
            {
                var result = context.Database.SqlQuery<T>(string.Format("EXEC {0}", storedProcedureName));
                return result.ToList();
            }
        }

        public void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (context.Database.Connection.State == ConnectionState.Closed)
            {
                context.Database.Connection.Open();
            }

            var command = context.Database.Connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            command.ExecuteNonQuery();
        }
    }
}
