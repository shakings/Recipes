using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using recipes.models.Profiles;
using Recipes.DataAccessLayer;
using Recipes.DataAccessLayer.Interfaces;
using Recipes.Models.Entity.Response.Ingredient;
using Recipes.Models.Entity.Response.Method;
using Recipes.Models.Entity.Response.Recipe;
using Recipes.Models.Entity.Response.UserLogin;
using Recipes.Models.Profiles;
using Recipes.Repository.Implementations.Builders;
using Recipes.Repository.Implementations.Service;
using Recipes.Repository.Interfaces.Builders;
using Recipes.Repository.Interfaces.Services;
using System;

namespace Recipes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string _connectionString;
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recipes.Api", Version = "v1" });
            });

            _connectionString = Configuration.GetConnectionString("ConnectionString");

            var recipesConnection = new gRecipesConnection();
            recipesConnection.SetString(_connectionString);

            services.AddScoped<IgRecipesConnection>(serviceProvider => recipesConnection);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfiles());
                mc.AddProfile(new RecipeProfiles());
                mc.AddProfile(new IngredientProfiles());
                mc.AddProfile(new MethodProfiles());

            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient<IExecute, MssqlExecute>();

            services.AddScoped<IUserRepositoryBuilder, UserRepositoryBuilder>();
            services.AddScoped<IUserRepositoryService, UserRepositoryServices>();
            services.AddScoped<IQuery<sp_Select_USR_UserLogin_Results>, MssqlQuery<sp_Select_USR_UserLogin_Results>>();


            services.AddScoped<IRecipeRepositoryBuilder, RecipetRepositoryBuilder>();
            services.AddScoped<IRecipeRepositoryService, RecipeRepositoryService>();
            services.AddScoped<IQuery<sp_Select_RCO_AllRecipes_Results>, MssqlQuery<sp_Select_RCO_AllRecipes_Results>>();

            services.AddScoped<IIngredientRepositoryBuilder, IngredientRepositoryBuilder>();
            services.AddScoped<IIngredientRepositoryService, IngredientRepositoryService>();
            services.AddScoped<IQuery<sp_Select_RIN_All_Ingredients_Results>, MssqlQuery<sp_Select_RIN_All_Ingredients_Results>>();

            services.AddScoped<IMethodRepositoryBuilder, MethodRepositoryBuilder>();
            services.AddScoped<IMethodRepositoryService, MethodRepositoryService>();
            services.AddScoped<IQuery<sp_Select_RME_MethodById_Results>, MssqlQuery<sp_Select_RME_MethodById_Results>>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recipes.Api v1"));
            }

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
