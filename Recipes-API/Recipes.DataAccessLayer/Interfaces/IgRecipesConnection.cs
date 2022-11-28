namespace Recipes.DataAccessLayer.Interfaces
{
    public interface IgRecipesConnection
    {
        string String { get; }
        void SetString(string connectionString);
    }
}