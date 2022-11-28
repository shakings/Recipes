using AutoMapper;
using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.Method;
using Recipes.Repository.Interfaces.Builders;
using Recipes.Repository.Interfaces.Services;

namespace Recipes.Repository.Implementations.Service
{
    public class MethodRepositoryService : IMethodRepositoryService
    {

        #region private variables

        private readonly IMethodRepositoryBuilder _methodRepositoryBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructors
        public MethodRepositoryService(IMethodRepositoryBuilder methodRepositoryBuilder,
                                       IMapper mapper)
        {
            this._methodRepositoryBuilder = methodRepositoryBuilder ?? throw new ArgumentNullException(nameof(methodRepositoryBuilder));
            this._mapper = mapper;
        }

        #endregion


        #region service-methods

        public async Task<IEnumerable<MethodResponseDto>> GetAllAsync()
        {
            var result = await this._methodRepositoryBuilder.GetAllAsync();

            return _mapper.Map<IEnumerable<MethodResponseDto>>(result);
        }

        public async Task<IEnumerable<MethodResponseDto>> GetByRecipeIdAsync(int recipeId)
        {
            var result =
                await this._methodRepositoryBuilder.GetByRecipeIdAsync(
                    new sp_Select_RME_MethodById_Parameters()
                    {
                        rco_Id = recipeId
                    });

            return _mapper.Map<IEnumerable<MethodResponseDto>>(result);
        }

        public async Task<int> InsertAsync(MethodRequestDto methodRequestDto)
        {
            var result =
                await this._methodRepositoryBuilder.InsertAsync(new sp_Insert_RME_Method_Parameters()
                {
                    rme_Description = methodRequestDto.Description,
                    rco_Id = methodRequestDto.RecipeId,
                });

            return result;
        }

        public async Task<int> UpdateAsync(MethodRequestDto methodRequestDto)
        {

            var result =
                await this._methodRepositoryBuilder.UpdateAsync(new sp_Update_RME_Method_Parameters()
                {
                    rme_Id = methodRequestDto.Id,
                    rme_Description = methodRequestDto.Description,
                    rco_Id = methodRequestDto.RecipeId
                });

            return result;
        }

        public async Task<int> DeleteAsync(MethodRequestDto methodRequestDto)
        {

            var result =
                 await this._methodRepositoryBuilder.DeleteAsync(new sp_Delete_RME_MethodsById_Parameters()
                 {
                     rme_Id = methodRequestDto.Id
                 });

            return result;
        }

        #endregion
    }
}
