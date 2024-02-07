using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.CrossCutting.AppDependecy;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration) 
    {
        service.AddDbContext<AppDbContext>(option => option.UseNpgsql(configuration.GetConnectionString("Default")));
        service.AddScoped<IMemberRepository, MemberRepository>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();

        return service;
    }
}
