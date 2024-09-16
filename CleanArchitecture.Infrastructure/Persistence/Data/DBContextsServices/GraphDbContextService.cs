using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence.Data.DBContextsServices;

public class GraphDbContextService : IDbContextBuilder
{
    public dynamic GetDbContextBasedOnType()
    {
        return "GraphDbContext";
    }
}
