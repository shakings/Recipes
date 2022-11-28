using Recipes.DataAccessLayer.Models;

namespace Recipes.DataAccessLayer.Interfaces
{
    public interface IQuery<T> where T : class
    {
        Task<T> Single(QueryParams getParams);
        Task<IEnumerable<T>> Many(QueryParams getParams);

    }
}
