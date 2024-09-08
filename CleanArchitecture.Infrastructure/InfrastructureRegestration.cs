using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CleanArchitecture.Infrastructure;

public static class InfrastructureRegestration
{
    public static void AddInfrastructureRegestration(this WebApplicationBuilder builder )
    {
        builder .Services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
    }
}
