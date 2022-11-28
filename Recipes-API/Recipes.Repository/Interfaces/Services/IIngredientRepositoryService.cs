using Recipes.Models.Dto.Request;
using Recipes.Models.Dtos.Response;

namespace Recipes.Repository.Interfaces.Services
{
    public interface IIngredientRepositoryService
    {
        /// <summary>
        /// GetAllAsync() Service
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IngredientResponseDto>> GetAllAsync();

        /// <summary>
        ///  GetByRecipeIdAsync() Service
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IngredientResponseDto>> GetByRecipeIdAsync(int RecipeId);

        /// <summary>
        /// InsertAsync() Service
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        Task<int> InsertAsync(IngredientRequestDto ingredient);

        /// <summary>
        /// UpdateAsync() Service
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(IngredientRequestDto ingredient);

        /// <summary>
        /// DeleteAsync() Service
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(int ingredientId);

    }
}
