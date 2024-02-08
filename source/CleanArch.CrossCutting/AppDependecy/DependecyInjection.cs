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
        var connection = configuration.GetConnectionString("Default");

        service.AddDbContext<AppDbContext>(option => option.UseNpgsql(connection));

        service.AddScoped<IMemberRepository, MemberRepository>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

        return service;
    }
}
