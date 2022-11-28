using Recipes.Models.Dtos.Response;

namespace Recipes.Models.Dtos.Request
{
    public class RecipeRequestDto
    {
        public int Id { get; set; }
        public string? RecipeName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Author { get; set; }
        public DateTime Created { get; set; }
        public List<IngredientResponseDto>? Ingredients { get; set; }
        public List<MethodResponseDto>? Methods { get; set; }
    }
}
