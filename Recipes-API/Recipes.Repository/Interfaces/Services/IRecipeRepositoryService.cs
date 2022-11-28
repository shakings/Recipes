using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;

namespace Recipes.Repository.Interfaces.Services
{
    public interface IRecipeRepositoryService
    {
        /// <summary>
        /// GetAllAsync() Service
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RecipeResponseDto>> GetAllAsync();

        /// <summary>
        /// InsertAsync() Service
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<int> InsertAsync(RecipeRequestDto recipe);

        /// <summary>
        /// UpdateAsync() Service
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(RecipeRequestDto recipe);

        /// <summary>
        /// DeleteAsync() Service
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(RecipeRequestDto recipe);
    }
}
