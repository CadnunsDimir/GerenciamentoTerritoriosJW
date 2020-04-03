using GerenciamentoTerritoriosJW.Core.Persistence;
using GerenciamentoTerritoriosJW.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTerritoriosJW
{
    public static class LocalDI
    {
        public static void AddLocalDependecies(this IServiceCollection services)
        {
            services.AddScoped<IDirectionRepository, LocalDirectionRepository>();

            
        }
    }
}
