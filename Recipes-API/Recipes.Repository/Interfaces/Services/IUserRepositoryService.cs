using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;

namespace Recipes.Repository.Interfaces.Services
{
    public interface IUserRepositoryService
    {
        /// <summary>
        /// LoginAsync() Service
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        Task<UserResponseDto> LoginAsync(UserLoginRequestDto userLogin);
    }
}
