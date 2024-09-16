using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.Data.DBContextsServices;

namespace CleanArchitecture.Infrastructure.Factories;

public static class DbContextFactory
{
    public static IDbContextBuilder ContextBuilder(string type)
    {
        switch (type)
        {
            case "Sql":
                return new SqlDbContextService();
            case "Cosmos":
                return new CosmosDbContextService();
            case "Graph":
                return new GraphDbContextService();
            default:
                return null;
        }
    }
}
