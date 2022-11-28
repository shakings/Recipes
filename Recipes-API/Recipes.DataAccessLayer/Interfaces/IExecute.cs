using Recipes.DataAccessLayer.Models;

namespace Recipes.DataAccessLayer.Interfaces
{
    public interface IExecute
    {
        Task<int> Sql(QueryParams queryParams);
        Task<T> Scaler<T>(QueryParams queryParams);
    }
}
