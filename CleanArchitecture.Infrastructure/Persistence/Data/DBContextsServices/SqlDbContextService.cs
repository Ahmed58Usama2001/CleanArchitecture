using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence.Data.DBContextsServices
{
    public class SqlDbContextService : IDbContextBuilder
    {
        public dynamic GetDbContextBasedOnType()
        {
            return "SqlDbContext";
        }
    }
}
