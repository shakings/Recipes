namespace Recipes.DataAccessLayer.Interfaces
{
    public abstract class lgRecipesBase
    {
        protected IgRecipesConnection recipesConnection;

        public lgRecipesBase(IgRecipesConnection recipesConnection)
        {
            this.recipesConnection = recipesConnection;
        }
    }
}
