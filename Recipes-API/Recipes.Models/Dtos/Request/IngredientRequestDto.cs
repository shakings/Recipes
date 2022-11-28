namespace Recipes.Models.Dto.Request
{
    public class IngredientRequestDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int RecipeId { get; set; }
    }
}
