using Recipes.Models.Entity.Request.Ingredient;
using Recipes.Models.Entity.Response.Ingredient;

namespace Recipes.Repository.Interfaces.Builders
{
    public interface IIngredientRepositoryBuilder
    {
        /// <summary>
        /// Get All the ingredients for recipe
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<sp_Select_RIN_All_Ingredients_Results>> GetAllAsync();

        /// <summary>
        ///  Get All the ingredients by recipes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<sp_Select_RIN_All_Ingredients_Results>>
            GetByRecipeIdAsync(sp_Select_RIN_IngredientById_Parameters sp_Select_RIN_IngredientById_Parameters);

        /// <summary>
        /// Insert a new ingredient entry  for recipe
        /// </summary>
        /// <param name="sp_Insert_RIN_Ingredient_Parameters"></param>
        /// <returns></returns>
        Task<int> InsertAsync(sp_Insert_RIN_Ingredient_Parameters sp_Insert_RIN_Ingredient_Parameters);

        /// <summary>
        /// Update a existing ingredient entry  for recipe
        /// </summary>
        /// <param name="sp_Update_RIN_IngredientById_Parameters"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(sp_Update_RIN_IngredientById_Parameters sp_Update_RIN_IngredientById_Parameters);

        /// <summary>
        /// Delete a existing ingredient entry  for recipe
        /// </summary>
        /// <param name="sp_Delete_RIN_IngredientById_Parameters"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(sp_Delete_RIN_IngredientById_Parameters sp_Delete_RIN_IngredientById_Parameters);
    }
}
