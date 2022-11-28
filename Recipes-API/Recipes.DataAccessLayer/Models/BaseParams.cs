using Dapper;
using System.Data;

namespace Recipes.DataAccessLayer.Models
{
    public class BaseParams
    {
        public string SqlQuery { get; set; }
        public DynamicParameters Parameters { get; set; }
        public CommandType commandType { get; set; } = CommandType.StoredProcedure;
        public string ConnectionString { get; set; }
        public bool UseTransaction { get; set; }

    }
}
