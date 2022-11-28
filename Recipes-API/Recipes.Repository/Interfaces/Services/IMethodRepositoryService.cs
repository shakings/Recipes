using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;

namespace Recipes.Repository.Interfaces.Services
{
    public interface IMethodRepositoryService
    {
        /// <summary>
        /// GetAllAsync() Service
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MethodResponseDto>> GetAllAsync();

        /// <summary>
        ///  GetByRecipeIdAsync() Service
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MethodResponseDto>> GetByRecipeIdAsync(int recipeId);

        /// <summary>
        /// InsertAsync() Service
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        Task<int> InsertAsync(MethodRequestDto method);

        /// <summary>
        /// UpdateAsync() Service
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(MethodRequestDto method);

        /// <summary>
        /// DeleteAsync() Service
        /// </summary>
        /// <param name="methodId"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(MethodRequestDto methodId);
    }
}
