using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Dtos.Request;
using Recipes.Repository.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Recipes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        #region Private

        private readonly IRecipeRepositoryService _recipeRepositoryService;

        #endregion

        #region constructor

        public RecipesController(IRecipeRepositoryService recipeRepositoryService)
        {
            _recipeRepositoryService = recipeRepositoryService ?? throw new ArgumentNullException(nameof(recipeRepositoryService));
        }

        #endregion

        #region Web-Methods

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await this._recipeRepositoryService.GetAllAsync();

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public async Task<IActionResult> Insert(RecipeRequestDto recipeRequestDto)
        {
            var response = await this._recipeRepositoryService.InsertAsync(recipeRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);

        }

        [HttpPut]
        [AllowAnonymous]
        [Route("Update")]
        public async Task<IActionResult> Update(RecipeRequestDto recipeRequestDto)
        {
            var response = await this._recipeRepositoryService.UpdateAsync(recipeRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }


        [HttpDelete]
        [AllowAnonymous]
        [Route("Delete")]
        public async Task<IActionResult> Delete(RecipeRequestDto recipeRequestDto)
        {
            var response = await this._recipeRepositoryService.DeleteAsync(recipeRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }

        #endregion
    }
}
