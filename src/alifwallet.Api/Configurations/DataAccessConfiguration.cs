using alifwallet.DataAccess.DbContexts;
using alifwallet.DataAccess.Interfaces;
using alifwallet.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace alifwallet.Api.Configurations
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DataBaseConnection")!;
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
