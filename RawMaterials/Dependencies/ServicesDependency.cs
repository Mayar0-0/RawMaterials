using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RawMaterials.Data;
using RawMaterials.Initializers.DataInitializers;
using RawMaterials.Models.Entities;
using RawMaterials.Models.IRepository;
using RawMaterials.Repository;
using RawMaterials.Repository.IRepository;
using RawMaterials.Service;
using RawMaterials.Service.IService;
using RawMaterials.Service.IService.UserServices;
using RawMaterials.Service.UserServices;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RawMaterials
{
    public static class ServicesDependency
    {
        public static void AddServicesDepndency(this IServiceCollection services)
        {
            // Authentication 
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
                opts.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<RawMaterialsContext>().AddDefaultTokenProviders();

            services.AddIdentityCore<Importer>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<RawMaterialsContext>().AddDefaultTokenProviders();

            services.AddIdentityCore<Suplier>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<RawMaterialsContext>().AddDefaultTokenProviders();

            services.AddIdentityCore<TeamWork>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<RawMaterialsContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => {

                // fixing redirection 404 of loginPath
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx => {
                        if (ctx.Request.Path.StartsWithSegments("/api"))
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    },

                    OnRedirectToAccessDenied = ctx => {
                        if (ctx.Request.Path.StartsWithSegments("/api"))
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };

                options.Cookie.Name = "RawMaterials";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                //options.Cookie.ApplicationCookie = 
            });

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // repositories
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped(typeof(ICategoryRepo), typeof(CategoryRepo));
            services.AddScoped(typeof(IMaterialRepo), typeof(MaterialRepo));



            // Business services injection
            services.AddScoped(typeof(IUserRegistrationService), typeof(UserRegistrationService));
            services.AddScoped(typeof(ILoginService), typeof(LoginService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IMaterialService), typeof(MaterialService));




            // app initializers
            services.AddAsyncInitializer<RoleInitializers>();
            services.AddAsyncInitializer<AdminsInitializers>();

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
        }
    }

}
