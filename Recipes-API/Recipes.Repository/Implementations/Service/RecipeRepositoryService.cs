using AutoMapper;
using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.Recipe;
using Recipes.Repository.Interfaces.Builders;
using Recipes.Repository.Interfaces.Services;

namespace Recipes.Repository.Implementations.Service
{
    public class RecipeRepositoryService : IRecipeRepositoryService
    {
        #region private variables

        private readonly IRecipeRepositoryBuilder _recipeRepositoryBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructor
        public RecipeRepositoryService(IRecipeRepositoryBuilder recipeRepositoryBuilder,
                                       IMapper mapper)
        {
            this._recipeRepositoryBuilder = recipeRepositoryBuilder ?? throw new ArgumentNullException(nameof(recipeRepositoryBuilder));
            this._mapper = mapper;
        }


        #endregion

        #region service-methods

        public async Task<IEnumerable<RecipeResponseDto>> GetAllAsync()
        {
            var result = await this._recipeRepositoryBuilder.GetAllAsync();

            return _mapper.Map<IEnumerable<RecipeResponseDto>>(result);
        }

        public async Task<int> InsertAsync(RecipeRequestDto recipe)
        {
            var parameters = _mapper.Map<sp_Insert_RCO_Recipes_Parameters>(recipe);
            var result =
                await this._recipeRepositoryBuilder.InsertAsync(parameters);

            return result;
        }

        public async Task<int> UpdateAsync(RecipeRequestDto recipe)
        {
            var parameters = _mapper.Map<sp_Update_RCO_Recipes_Parameters>(recipe);
            var result =
                await this._recipeRepositoryBuilder.UpdateAsync(parameters);

            return result;
        }

        public async Task<int> DeleteAsync(RecipeRequestDto recipe)
        {
            var parameters = _mapper.Map<sp_Delete_RCO_RecipesById_Parameters>(recipe);
            var result =
                await this._recipeRepositoryBuilder.DeleteAsync(parameters);

            return result;
        }



        #endregion
    }
}
