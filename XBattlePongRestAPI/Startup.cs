using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using XBattlePongRestAPI.DataAccessAndDBContext;

namespace XBattlePongRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContextPool<XBattlePongDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("XBattlePongDbConnection")));
            services.AddScoped<IEventosAccessProvider, EventosAccessProvider>();
            services.AddScoped<IPartidasAccessProvider, PartidasAccessProvider>();
            services.AddScoped<IReglasDelEventoAccessProvider, ReglasDelEventoAccessProvider>();
            services.AddScoped<ITokenConEventoAccessProvider, TokenConEventoAccessProvider>();
            services.AddScoped<ICatalogoDeNavesAccessProvider, CatalogoDeNavesAccessProvider>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
