using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Services;

public static class ServicesRegestration
{
    public static void AddServicesRegestrations (this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICarServices,CarServices> ();
    }
}
