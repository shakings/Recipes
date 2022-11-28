using Dapper;
using Recipes.DataAccessLayer.Interfaces;
using Recipes.DataAccessLayer.Models;

namespace Recipes.DataAccessLayer
{
    public class MssqlExecute : DALBase, IExecute
    {
        public async Task<T> Scaler<T>(QueryParams queryParams)
        {
            return await WrapQuery<T>(
                queryParams: queryParams,
                queryFunc: async (con, trans, queryParams) =>
                 {
                     return await con.ExecuteScalarAsync<T>(
                         sql: queryParams.SqlQuery,
                         param: queryParams.Parameters,
                         transaction: trans,
                         commandType: queryParams.commandType

                         );
                 });
        }

        public async Task<int> Sql(QueryParams queryParams)
        {
            return await WrapQuery<int>(
                 queryParams: queryParams,
                 queryFunc: async (con, trans, queryParams) =>
                 {
                     return await con.ExecuteAsync(
                         sql: queryParams.SqlQuery,
                         param: queryParams.Parameters,
                         transaction: trans,
                         commandType: queryParams.commandType
                         );
                 });
        }

    }
}