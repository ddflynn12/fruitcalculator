using Dal;
using Dal.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitMarket
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<Repository<CartItem>, FruitMarketRepository>();
            services.AddScoped<Repository<ICalculator<Cart>>, PromotionRepository>();
        }
    }
}
