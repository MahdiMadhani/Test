using DataAccess;
using DataAccess.Domain.Guarantees;
using DayanaCore.Infrastructure.Application;
using DayanaCore.Infrastructure.Domain;
using DependencyInjection;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Authorization.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using Test.Host.GraphQl.Tools.Schemas;
using ServiceLifetime = GraphQL.DI.ServiceLifetime;

namespace Test.Host.GraphQl
{
    public class Startup
    {
        readonly string Policy = "AllowAll";
        private const string DefaultConnection = "DefaultConnection";
        private const string DataAccessNameSpace = "DataAccess";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(Policy, p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddAutoMapper(typeof(GuaranteeMapper).Assembly);
            services.AddAutoMapper(cfg => cfg.AddProfile<GuaranteeMapper>(),
                AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<AppSchema>();
            services.TryAddTransient<IClaimsPrincipalAccessor, DefaultClaimsPrincipalAccessor>();
            services.AddStartupConfiguration(Configuration);
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSingleton<IValidationRule, GraphQLValidationRule>();

            GraphQL.MicrosoftDI.GraphQLBuilderExtensions.AddGraphQL(services)
                .AddServer(true)
                .AddSchema<AppSchema>(ServiceLifetime.Scoped)
                .ConfigureExecution(options =>
                    {
                        options.EnableMetrics = false;
                    })
                // Add required services for GraphQL request/response de/serialization
                .AddSystemTextJson() // For .NET Core 3+
                .AddErrorInfoProvider(opt =>
                {
                    opt.ExposeExceptionStackTrace = false;
                    opt.ExposeData = true;
                    opt.ExposeCode = true;
                    opt.ExposeCodes = true;
                })
                .AddGraphTypes(typeof(AppSchema).Assembly)
                .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
            //     .AddGraphQLAuthorization(options =>
            // {
            //     options.AddPolicy("Authorized", p => p.RequireAuthenticatedUser());
            // });

            
            services.AddDbContext<Context>(options =>
    options.UseSqlServer(Configuration.GetConnectionString(DefaultConnection), m => m.MigrationsAssembly(DataAccessNameSpace))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


            // services.AddAuthentication("token")
            //     .AddOAuth2Introspection("token", options =>
            //     {
            //         options.Authority = "https://identitytest.itdlogisoft.com";
            //
            //         // this maps to the API resource name and secret
            //         options.ClientId = "ContractApi";
            //         options.ClientSecret = "02367c60-d4d8-9e07-df98-ba37d5707a0d";
            //     });
            services
                .AddAuthentication(o =>
                {
                    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://identitytest.itdlogisoft.com";
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors(Policy);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<GraphQLMiddleware<AppSchema>>();
            app.UseGraphQLPlayground(options: new PlaygroundOptions());
            //app.UseMiddleware<ErrorHandlingMiddleWare>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
