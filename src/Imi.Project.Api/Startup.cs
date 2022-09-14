using System;
using System.IO;
using System.Reflection;
using System.Text;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Imi.Project.Api.Core.Helpers;
using Imi.Project.Api.Core.Images;
using Imi.Project.Api.Core.Interfaces.Data;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Images;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Infrastructure.Data.Repositories;
using Imi.Project.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api
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


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Imi Project - PRI WEB API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] { }}
    });
            });

            services.AddDbContext<ITInternshipsContextDb>(options => options.UseSqlServer(
                Configuration.GetConnectionString("IMI-Maene-Jean-Baptiste"), b => b.MigrationsAssembly("Imi.Project.Api.Infrastructure")));

            services
                .AddIdentity<BasePerson, IdentityRole>(options =>
                {
                    // User configurations
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+יטאשצפüûגהכךןמח";
                    // Lockout options
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                    options.Lockout.MaxFailedAccessAttempts = 5;

                })
                .AddEntityFrameworkStores<ITInternshipsContextDb>();


            services.AddControllers();

            services.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                        ValidAudience = Configuration["JWTConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTConfiguration:SigningKey"]))
    
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanRead", policy =>
                {
                    policy.RequireClaim("acceptedtermsandconditions", "True");
                });
                options.AddPolicy("CanEdit", policy =>
                {
                    policy.RequireClaim("acceptedtermsandconditions", "True" );
                });
                options.AddPolicy("CanCreate", policy =>
                {
                    policy.RequireClaim("acceptedtermsandconditions", "True");
                });
                options.AddPolicy("CanDelete", policy =>
                {
                    policy.RequireClaim("acceptedtermsandconditions", "True" );
                });
            });

            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IMatchRepository, MatchRepository>();

            services.AddScoped<ISearchRepository, SearchRepository>();

            services.AddScoped<IDataSeederService, DataSeederService>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IUserRepository<BasePerson, BasePersonDto>, UserRepository<BasePerson, BasePersonDto>>();

            services.AddScoped<ISearchService, SearchService>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IRecruiterService, RecruiterService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IUserService, UserService>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Imi Project - PRI WEB API");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
