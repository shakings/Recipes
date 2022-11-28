using Recipes.Models.Entity.Request.UserLogin;
using Recipes.Models.Entity.Response.UserLogin;

namespace Recipes.Repository.Interfaces.Builders
{
    public interface IUserRepositoryBuilder
    {
        Task<sp_Select_USR_UserLogin_Results> LoginAsync(sp_Select_USR_UserLogin_Parameters sp_Select_USR_UserLogin_Parameters);
    }
}
