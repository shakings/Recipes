using Recipes.DataAccessLayer.Interfaces;
using Recipes.DataAccessLayer.Models;
using Recipes.Models.Entity.Request.Recipe;
using Recipes.Models.Entity.Response.Recipe;
using Recipes.Repository.Interfaces.Builders;

namespace Recipes.Repository.Implementations.Builders
{
    public class RecipetRepositoryBuilder : lgRecipesBase, IRecipeRepositoryBuilder
    {
        #region private variables

        private readonly IQuery<sp_Select_RCO_AllRecipes_Results> _query;
        private readonly IExecute _execute;

        #endregion

        #region constructors

        public RecipetRepositoryBuilder(IQuery<sp_Select_RCO_AllRecipes_Results> query,
                                              IExecute execute,
                                              IgRecipesConnection igRecipesConnection) : base(igRecipesConnection)
        {
            _query = query;
            _execute = execute;
        }

        #endregion

        #region data-methods

        public async Task<IEnumerable<sp_Select_RCO_AllRecipes_Results>> GetAllAsync()
        {
            return await _query.Many(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Select_RCO_AllRecipes]",
                ConnectionString = recipesConnection.String
            });
        }


        public async Task<int> InsertAsync(sp_Insert_RCO_Recipes_Parameters sp_Insert_RCO_Recipes_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Insert_RCO_Recipes]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Insert_RCO_Recipes_Parameters)
            });

            return results;
        }

        public async Task<int> UpdateAsync(sp_Update_RCO_Recipes_Parameters sp_Update_RCO_Recipes_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Update_RCO_Recipes]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Update_RCO_Recipes_Parameters)
            });

            return results;
        }

        public async Task<int> DeleteAsync(sp_Delete_RCO_RecipesById_Parameters sp_Delete_RCO_RecipesById_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Delete_RCO_Recipes]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Delete_RCO_RecipesById_Parameters)
            });

            return results;
        }


        #endregion
    }
}
