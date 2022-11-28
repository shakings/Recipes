using Recipes.Models.Entity.Request.Recipe;
using Recipes.Models.Entity.Response.Recipe;

namespace Recipes.Repository.Interfaces.Builders
{
    public interface IRecipeRepositoryBuilder
    {
        /// <summary>
        /// Get All recipes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<sp_Select_RCO_AllRecipes_Results>> GetAllAsync();

        /// <summary>
        /// Insert a new recipe entry 
        /// </summary>
        /// <param name="recipeRequestEntity"></param>
        /// <returns></returns>
        Task<int> InsertAsync(sp_Insert_RCO_Recipes_Parameters sp_Insert_RCO_Recipes_Parameters);

        /// <summary>
        /// Update a existing recipe entry 
        /// </summary>
        /// <param name="sp_Update_RCO_Recipes_Parameters"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(sp_Update_RCO_Recipes_Parameters sp_Update_RCO_Recipes_Parameters);

        /// <summary>
        /// Delete a existing recipe entry 
        /// </summary>
        /// <param name="sp_Delete_RCO_RecipesById_Parameters"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(sp_Delete_RCO_RecipesById_Parameters sp_Delete_RCO_RecipesById_Parameters);
    }
}
