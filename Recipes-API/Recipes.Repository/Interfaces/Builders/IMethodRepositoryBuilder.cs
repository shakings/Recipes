using Recipes.Models.Entity.Request.Method;
using Recipes.Models.Entity.Response.Method;

namespace Recipes.Repository.Interfaces.Builders
{
    public interface IMethodRepositoryBuilder
    {
        /// <summary>
        /// Get All the Methods for recipes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<sp_Select_RME_MethodById_Results>> GetAllAsync();

        /// <summary>
        ///  Get All the Methods by recipes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<sp_Select_RME_MethodById_Results>> GetByRecipeIdAsync(sp_Select_RME_MethodById_Parameters sp_Select_RME_MethodById_Parameters);

        /// <summary>
        /// Insert a new method entry for recipe
        /// </summary>
        /// <param name="sp_Insert_RME_Method_Parameters"></param>
        /// <returns></returns>
        Task<int> InsertAsync(sp_Insert_RME_Method_Parameters sp_Insert_RME_Method_Parameters);

        /// <summary>
        /// Update a existing method entry for recipe
        /// </summary>
        /// <param name="sp_Update_RME_Method_Parameters"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(sp_Update_RME_Method_Parameters sp_Update_RME_Method_Parameters);

        /// <summary>
        /// Delete a existing method entry  for recipe
        /// </summary>
        /// <param name="sp_Delete_RME_MethodsById_Parameters"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(sp_Delete_RME_MethodsById_Parameters sp_Delete_RME_MethodsById_Parameters);
    }
}
