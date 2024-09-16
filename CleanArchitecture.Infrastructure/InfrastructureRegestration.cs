using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.Data.DBContextsServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CleanArchitecture.Infrastructure;

public static class InfrastructureRegestration
{
    public static void AddInfrastructureRegestration(this WebApplicationBuilder builder )
    {
        builder.Services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
        builder.Services.AddTransient<IDbContextBuilder,SqlDbContextService>();
        builder.Services.AddTransient<IDbContextBuilder,CosmosDbContextService>();
        builder.Services.AddTransient<IDbContextBuilder,GraphDbContextService>();
    }
}
