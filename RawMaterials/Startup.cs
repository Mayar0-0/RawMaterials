using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RawMaterials.Data;
using RawMaterials.Dto;
using RawMaterials.Models.Entities;
using RawMaterials.Models.IRepository;
using RawMaterials.Models.Repository;
using RawMaterials.Repository;

namespace RawMaterials
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
            services.AddDbContextPool<RawMaterialsContext>(
                 options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<RawMaterialsContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => {

                options.LoginPath = "/Account/Login";
                options.Cookie.Name = "RawMaterials";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
             services.AddScoped<IUserRepo, UserRepo>();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Swgger config Url"https://localhost:44369/swagger/Raw_Materials/swagger.json"
            services.AddSwaggerGen(options => {
                            options.SwaggerDoc("Raw_Materials",
                                new Microsoft.OpenApi.Models.OpenApiInfo()
                                {
                                    Title = "Raw Materials APi",
                                    Version = "1",

                                }
                                    );
                        });
      /*      services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = Jwtbearerdefaults});*/
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
               app.UseSwagger();
            app.UseSwaggerUI(Options => {
                Options.SwaggerEndpoint("/swagger/Raw_Materials/swagger.json", "Raw Material");
                Options.RoutePrefix = "";
            });

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=Index}/{id?}");
            });
        }
    }
}
