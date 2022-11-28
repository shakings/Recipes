using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Dtos.Request;
using Recipes.Repository.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Recipes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        #region Private

        private readonly IUserRepositoryService _userRepositoryService;

        #endregion

        #region constructor

        public UserController(IUserRepositoryService userRepositoryService)
        {
            _userRepositoryService = userRepositoryService ?? throw new ArgumentNullException(nameof(userRepositoryService));

        }

        #endregion

        #region Web-Methods

        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> UserLogin(UserLoginRequestDto userLoginRequestDto)
        {
            var response = await
                this._userRepositoryService.LoginAsync(userLoginRequestDto);

            return response == null ? NotFound() : Ok(response);
        }

        #endregion
    }
}
