namespace Recipes.Repository
{
    public interface IBaseRepository
    {
        public Task<T> QueryFirst<T>(string query, object? parameters = null);

        public Task<T> QueryFirstOrDefault<T>(string query, object? parameters = null);

        public Task<T> QuerySingle<T>(string query, object? parameters = null);

        public Task<T> QuerySingleOrDefault<T>(string query, object? parameters = null);

        public Task<int> Execute(string query, object? parameters = null);

        public Task<T> QueryFirstStoredProcedure<T>(string query, object? parameters = null);

        public Task<int> ExecuteStoredProcedure(string query, object? parameters = null);

        public Task<List<T>> QueryList<T>(string query, object? parameters = null) where T : class;
    }
}
