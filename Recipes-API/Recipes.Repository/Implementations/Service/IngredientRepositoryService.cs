using AutoMapper;
using Recipes.Models.Dto.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.Ingredient;
using Recipes.Repository.Interfaces.Builders;
using Recipes.Repository.Interfaces.Services;

namespace Recipes.Repository.Implementations.Service
{
    public class IngredientRepositoryService : IIngredientRepositoryService
    {

        #region private variables

        private readonly IIngredientRepositoryBuilder _ingredientRepositoryBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructors
        public IngredientRepositoryService(IIngredientRepositoryBuilder ingredientRepositoryBuilder,
                                           IMapper mapper)
        {
            this._ingredientRepositoryBuilder = ingredientRepositoryBuilder ?? throw new ArgumentNullException(nameof(ingredientRepositoryBuilder));
            this._mapper = mapper;
        }

        #endregion

        #region service-methods

        public async Task<IEnumerable<IngredientResponseDto>> GetAllAsync()
        {
            var result = await this._ingredientRepositoryBuilder.GetAllAsync();

            return _mapper.Map<IEnumerable<IngredientResponseDto>>(result);
        }

        public async Task<IEnumerable<IngredientResponseDto>> GetByRecipeIdAsync(int recipeId)
        {
            var result = await this._ingredientRepositoryBuilder.GetByRecipeIdAsync(
              new sp_Select_RIN_IngredientById_Parameters()
              {
                  rco_Id = recipeId
              });

            return _mapper.Map<IEnumerable<IngredientResponseDto>>(result);
        }

        public async Task<int> InsertAsync(IngredientRequestDto ingredient)
        {
            var result =
                await this._ingredientRepositoryBuilder.InsertAsync(new sp_Insert_RIN_Ingredient_Parameters()
                {
                    rin_Description = ingredient.Description,
                    rco_Id = ingredient.RecipeId
                });

            return result;
        }

        public async Task<int> UpdateAsync(IngredientRequestDto ingredient)
        {

            var result =
                await this._ingredientRepositoryBuilder.UpdateAsync(new sp_Update_RIN_IngredientById_Parameters()
                {
                    rin_Id = ingredient.Id,
                    rin_Description = ingredient.Description,
                    rco_Id = ingredient.RecipeId
                });

            return result;
        }

        public async Task<int> DeleteAsync(int ingredientId)
        {
            var result =
                  await this._ingredientRepositoryBuilder.DeleteAsync(
                      new sp_Delete_RIN_IngredientById_Parameters()
                      {
                          rin_Id = ingredientId
                      });

            return result;
        }

        #endregion
    }
}
