using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence.Data.DBContextsServices;

public class CosmosDbContextService : IDbContextBuilder
{
    public dynamic GetDbContextBasedOnType()
    {
        return "CosmosDbContext";
    }
}
