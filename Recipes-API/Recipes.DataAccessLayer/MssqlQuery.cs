using Dapper;
using Recipes.DataAccessLayer.Interfaces;
using Recipes.DataAccessLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace Recipes.DataAccessLayer
{
    public class MssqlQuery<T> : IQuery<T> where T : class
    {
        public async Task<IEnumerable<T>> Many(QueryParams queryParams)
        {
            return await WrapQuery<IEnumerable<T>>(
                queryParams: queryParams,
                queryFunc: async (connection, transaction, queryparms) =>
                {
                    return await connection.QueryAsync<T>(
                        sql: queryParams.SqlQuery,
                        param: queryParams.Parameters,
                        transaction: transaction,
                        commandType: queryParams.commandType
                        );
                });
        }

        public async Task<T> Single(QueryParams queryParams)
        {
            return await WrapQuery<T>(
               queryParams: queryParams,
               queryFunc: async (connection, transaction, queryparms) =>
               {
                   return await connection.QueryFirstOrDefaultAsync<T>(
                       sql: queryParams.SqlQuery,
                       param: queryParams.Parameters,
                       transaction: transaction,
                       commandType: queryParams.commandType);
               });
        }


        private async Task<TResult> WrapQuery<TResult>(QueryParams queryParams,
                Func<SqlConnection, IDbTransaction,
                QueryParams, Task<TResult>> queryFunc)
        {
            using (SqlConnection connection = new SqlConnection(queryParams.ConnectionString))
            {
                if (queryParams.UseTransaction)
                {
                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        try
                        {

                            TResult rows = await queryFunc(connection, tran, queryParams);
                            tran.Commit();
                            return rows;

                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }

                }
                else
                {
                    return await queryFunc(connection, null, queryParams);
                }
            }
        }
    }
}
