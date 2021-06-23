using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTaskFor66bit.BLL.Interfaces;
using TestTaskFor66bit.BLL.ModelsDTO;
using TestTaskFor66bit.BLL.Services;
using TestTaskFor66bit.DAL.EF;
using TestTaskFor66bit.DAL.Interfaces;
using TestTaskFor66bit.DAL.Repositories;

namespace TestTaskFor66bit
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
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));//����� ����� �� ������ ������ ������ ������ 
            services.AddTransient<IPlayerRepository, PlayerRepository>();//������ ������ � ������ ������ �������
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamRepository,TeamRepository>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ISaver, Saver>();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Connectionstring")));
             
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
        private static MapperConfiguration GetMapperConfiguration()
        {
            MapperConfiguration configuration = new MapperConfiguration(config => { config.AddProfile<AutoMapperConfiguration>(); });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
