using System.Data;

namespace Recipes.DataAccessLayer.Connection
{
    public class RecipeDbConnection
    {
        public IDbConnection Connection;

        public RecipeDbConnection(IDbConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
    }
}
