using Recipes.DataAccessLayer.Interfaces;

namespace Recipes.DataAccessLayer
{
    public class gRecipesConnection : IgRecipesConnection
    {
        public string String { get; private set; }

        public void SetString(string connectionString)
        {
            if (ValueIsInvalid(String) && ValueIsInvalid(connectionString))
            {
                throw new ArgumentNullException($"{nameof(connectionString)} cannot be null");
            }

            String = connectionString;
        }

        private static bool ValueIsInvalid(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
