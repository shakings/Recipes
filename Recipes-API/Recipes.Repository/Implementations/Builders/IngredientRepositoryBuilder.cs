using Recipes.DataAccessLayer.Interfaces;
using Recipes.DataAccessLayer.Models;
using Recipes.Models.Entity.Request.Ingredient;
using Recipes.Models.Entity.Response.Ingredient;
using Recipes.Repository.Interfaces.Builders;

namespace Recipes.Repository.Implementations.Builders
{
    public class IngredientRepositoryBuilder : lgRecipesBase, IIngredientRepositoryBuilder
    {
        #region private variables

        private readonly IQuery<sp_Select_RIN_All_Ingredients_Results> _query;
        private readonly IExecute _execute;

        #endregion

        #region constructors

        public IngredientRepositoryBuilder(IQuery<sp_Select_RIN_All_Ingredients_Results> query,
                                           IExecute execute,
                                           IgRecipesConnection igRecipesConnection) : base(igRecipesConnection)
        {
            _query = query;
            _execute = execute;
        }

        #endregion

        #region data-methods

        public async Task<IEnumerable<sp_Select_RIN_All_Ingredients_Results>> GetAllAsync()
        {
            return await _query.Many(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Select_RIN_AllIngredients]",
                ConnectionString = recipesConnection.String
            });
        }

        public async Task<IEnumerable<sp_Select_RIN_All_Ingredients_Results>>
            GetByRecipeIdAsync(sp_Select_RIN_IngredientById_Parameters sp_Select_RIN_IngredientById_Parameters)
        {
            return await _query.Many(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Select_RIN_IngredientById]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Select_RIN_IngredientById_Parameters)
            });
        }

        public async Task<int> InsertAsync(sp_Insert_RIN_Ingredient_Parameters sp_Insert_RIN_Ingredient_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Insert_RIN_Ingredient]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Insert_RIN_Ingredient_Parameters)
            });

            return results;
        }

        public async Task<int> UpdateAsync(sp_Update_RIN_IngredientById_Parameters sp_Update_RIN_IngredientById_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Update_RIN_IngredientById]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Update_RIN_IngredientById_Parameters)
            });

            return results;
        }

        public async Task<int> DeleteAsync(sp_Delete_RIN_IngredientById_Parameters sp_Delete_RIN_IngredientById_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Delete_RIN_IngredientById]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Delete_RIN_IngredientById_Parameters)
            });

            return results;
        }

        #endregion
    }
}
