using Recipes.DataAccessLayer.Interfaces;
using Recipes.DataAccessLayer.Models;
using Recipes.Models.Entity.Request.Method;
using Recipes.Models.Entity.Response.Method;
using Recipes.Repository.Interfaces.Builders;

namespace Recipes.Repository.Implementations.Builders
{
    public class MethodRepositoryBuilder : lgRecipesBase, IMethodRepositoryBuilder
    {

        #region private variables

        private readonly IQuery<sp_Select_RME_MethodById_Results> _query;
        private readonly IExecute _execute;

        #endregion

        #region constructors

        public MethodRepositoryBuilder(IQuery<sp_Select_RME_MethodById_Results> query,
                                       IExecute execute,
                                       IgRecipesConnection igRecipesConnection) : base(igRecipesConnection)
        {
            _query = query;
            _execute = execute;
        }

        #endregion

        #region data-methods

        public async Task<IEnumerable<sp_Select_RME_MethodById_Results>> GetAllAsync()
        {
            return await _query.Many(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Select_RME_AllMethods]",
                ConnectionString = recipesConnection.String
            });
        }

        public async Task<IEnumerable<sp_Select_RME_MethodById_Results>>
            GetByRecipeIdAsync(sp_Select_RME_MethodById_Parameters sp_Select_RME_MethodById_Parameters)
        {
            return await _query.Many(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Select_RME_MethodById]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Select_RME_MethodById_Parameters)
            });
        }

        public async Task<int> InsertAsync(sp_Insert_RME_Method_Parameters sp_Insert_RME_Method_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Insert_RME_Method]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Insert_RME_Method_Parameters)
            });

            return results;
        }
        public async Task<int> UpdateAsync(sp_Update_RME_Method_Parameters sp_Update_RME_Method_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Update_RME_Method]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Update_RME_Method_Parameters)
            });

            return results;
        }

        public async Task<int> DeleteAsync(sp_Delete_RME_MethodsById_Parameters sp_Delete_RME_MethodsById_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Delete_RME_MethodsById]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Delete_RME_MethodsById_Parameters)
            });

            return results;
        }



        #endregion
    }
}
