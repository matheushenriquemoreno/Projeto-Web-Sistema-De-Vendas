using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_SistemaWeb.Models;
using Projeto_SistemaWeb.Data;
using Projeto_SistemaWeb.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Projeto_SistemaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // configura os services da aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //Esta lambda determina se o consentimento do usuário para cookies não essenciais é necessário para uma determinada solicitação.

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            /* coneção com o banco de dados mysql */
            services.AddDbContext<Projeto_SistemaWebContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("Projeto_SistemaWebContext"), builder =>
                        builder.MigrationsAssembly("Projeto_SistemaWeb")));

            services.AddScoped<SeedingService>(); // registrando o nosso servico no sistema de injeção de dependencia na aplicação.
            services.AddScoped<SellerServices>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<RegistroVendaService>();

        }

        // configura questao relacinadas ao comportamento das requisicoes / pipeline htpp
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seendingService) // 
        {

            var enUs = new CultureInfo("en-US");
            var localizacaoOption = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUs),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };

            app.UseRequestLocalization(localizacaoOption);

            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
                seendingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
