using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Dto.Request;
using Recipes.Repository.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Recipes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {

        #region Private

        private readonly IIngredientRepositoryService _ingredientRepositoryService;

        #endregion

        #region constructor

        public IngredientsController(IIngredientRepositoryService ingredientRepositoryService)
        {
            _ingredientRepositoryService = ingredientRepositoryService ?? throw new ArgumentNullException(nameof(ingredientRepositoryService));
        }

        #endregion

        #region Web-Methods

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await this._ingredientRepositoryService.GetAllAsync();

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetByRecipeId")]
        public async Task<IActionResult> GetByRecipeId(int recipeId)
        {
            var response = await this._ingredientRepositoryService.GetByRecipeIdAsync(recipeId);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public async Task<IActionResult> Insert(IngredientRequestDto ingredientRequestDto)
        {
            var response = await this._ingredientRepositoryService.InsertAsync(ingredientRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("Update")]
        public async Task<IActionResult> Update(IngredientRequestDto ingredientRequestDto)
        {
            var response = await this._ingredientRepositoryService.UpdateAsync(ingredientRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int rim_Id)
        {
            var response = await this._ingredientRepositoryService.DeleteAsync(rim_Id);

            return response >= 0 ? BadRequest() : Ok(response);
        }

        #endregion
    }
}
