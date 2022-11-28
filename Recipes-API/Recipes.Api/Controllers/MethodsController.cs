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
    public class MethodsController : ControllerBase
    {
        #region Private

        private readonly IMethodRepositoryService _methodRepositoryService;

        #endregion

        #region constructor

        public MethodsController(IMethodRepositoryService methodRepositoryService)
        {
            _methodRepositoryService = methodRepositoryService ?? throw new ArgumentNullException(nameof(methodRepositoryService));
        }

        #endregion

        #region Web-Methods

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await this._methodRepositoryService.GetAllAsync();

            return response == null ? NotFound() : Ok(response);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public async Task<IActionResult> Insert(MethodRequestDto methodRequestDto)
        {
            var response = await this._methodRepositoryService.InsertAsync(methodRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("Update")]
        public async Task<IActionResult> Update(MethodRequestDto methodRequestDto)
        {
            var response = await this._methodRepositoryService.UpdateAsync(methodRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }


        [HttpDelete]
        [AllowAnonymous]
        [Route("Delete")]
        public async Task<IActionResult> Delete(MethodRequestDto methodRequestDto)
        {
            var response = await this._methodRepositoryService.DeleteAsync(methodRequestDto);

            return response >= 0 ? BadRequest() : Ok(response);
        }

        #endregion
    }
}
