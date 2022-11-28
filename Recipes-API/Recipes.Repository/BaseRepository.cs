using Dapper;
using Recipes.DataAccessLayer.Connection;
using System.Data;

namespace Recipes.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IDbConnection _connection;

        public BaseRepository(RecipeDbConnection connection)
        {
            _connection = connection.Connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<int> Execute(string query, object? parameters = null)
        {
            try
            {
                if (_connection.State is ConnectionState.Closed or ConnectionState.Broken)
                {
                    _connection.Open();
                }

                return await _connection.ExecuteAsync(query, parameters);

            }
            finally
            {
            }
        }

        public async Task<int> ExecuteStoredProcedure(string query, object? parameters = null)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return await _connection.ExecuteAsync(query,
                                                      parameters,
                                                      commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                var message = ex.Message;
                return await _connection.ExecuteAsync(query,
                                                 parameters,
                                                 commandType: CommandType.StoredProcedure);
            }
            finally
            {
            }
        }

        public async Task<T> QueryFirstStoredProcedure<T>(string query,
                                                     object? parameters = null)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return await _connection.QueryFirstAsync<T>(query,
                                                            parameters,
                                                            commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return default(T);
            }
            finally
            {
            }
        }

        public async Task<T> QueryFirst<T>(string query, object? parameters = null)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return await _connection.QueryFirstAsync<T>(query,
                                                            parameters);
            }
            finally
            {
            }
        }

        public async Task<T> QueryFirstOrDefault<T>(string query, object? parameters = null)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return await _connection.QueryFirstOrDefaultAsync<T>(query,
                                                                     parameters,
                                                                     commandType: CommandType.StoredProcedure);
            }
            finally
            {
            }
        }

        public async Task<List<T>> QueryList<T>(string query,
                                               object? parameters = null) where T : class
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return (List<T>)await _connection.QueryAsync<T>(query,
                                                                parameters,
                                                                commandType: CommandType.StoredProcedure);
            }
            finally
            {
            }
        }

        public async Task<T> QuerySingle<T>(string query,
                                            object? parameters = null)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return await _connection.QuerySingleAsync<T>(query,
                                                             parameters);
            }
            finally
            {
            }
        }

        public async Task<T> QuerySingleOrDefault<T>(string query,
                                                     object? parameters = null)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return await _connection.QuerySingleOrDefaultAsync<T>(query,
                                                                      parameters);
            }
            finally
            {
            }
        }
    }
}
