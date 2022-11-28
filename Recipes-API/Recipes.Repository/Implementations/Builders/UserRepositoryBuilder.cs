using Recipes.DataAccessLayer.Interfaces;
using Recipes.DataAccessLayer.Models;
using Recipes.Models.Entity.Request.UserLogin;
using Recipes.Models.Entity.Response.UserLogin;
using Recipes.Repository.Interfaces.Builders;

namespace Recipes.Repository.Implementations.Builders
{
    public class UserRepositoryBuilder : lgRecipesBase, IUserRepositoryBuilder
    {
        #region private variables

        private readonly IQuery<sp_Select_USR_UserLogin_Results> _query;
        private readonly IExecute _execute;

        #endregion

        #region constructors

        public UserRepositoryBuilder(IQuery<sp_Select_USR_UserLogin_Results> query,
                                     IExecute execute,
                                     IgRecipesConnection igRecipesConnection) : base(igRecipesConnection)
        {
            _query = query;
            _execute = execute;
        }

        #endregion

        #region data-methods

        public async Task<sp_Select_USR_UserLogin_Results>
            LoginAsync(sp_Select_USR_UserLogin_Parameters sp_Select_USR_UserLogin_Parameters)
        {
            return await _query.Single(new QueryParams
            {
                SqlQuery = "[dbo].[sp_Get_USR_UserRoles]",
                ConnectionString = recipesConnection.String,
                Parameters = new Dapper.DynamicParameters(sp_Select_USR_UserLogin_Parameters)
            });
        }

        #endregion
    }
}
