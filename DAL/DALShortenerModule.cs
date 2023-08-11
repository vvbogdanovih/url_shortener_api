using DAL.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALShortenerModule
    {
        public static void Load(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ShortenerDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("MyConnection")));
        }
    }
}
