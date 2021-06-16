using AutoMapper;
using AutoMapper.EquivalencyExpression;
using HRTraining.Domain.Context;
using HRTraining.Domain.Entities.Activities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HRTraining
{
    public static class TypeExtensions
    {
        public static string GetTypeName(this Type type)
        {
            if (!type.IsGenericType)
                return type.Name;

            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.GetTypeName()).ToArray());
            return $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
    }

    public class TypeNameSerializationBinder : ISerializationBinder
    {
        private readonly Assembly[] _assemblies;
        private readonly ConcurrentDictionary<string, Type> _typeLookup;

        public TypeNameSerializationBinder(Assembly[] assemblies)
        {
            _assemblies = assemblies;
            _typeLookup = new ConcurrentDictionary<string, Type>();
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.GetTypeName();
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            return _typeLookup.GetOrAdd(typeName, s => _assemblies.SelectMany(x => x.GetTypes()).FirstOrDefault(x => x.Name == typeName));
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _assemblies = GetAssemblies().ToArray();
        }

        private IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(Startup).Assembly;
        }

        public IConfiguration Configuration { get; }
        private readonly Assembly[] _assemblies;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddControllers().AddNewtonsoftJson(o => {
                o.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                o.SerializerSettings.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
                o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                o.SerializerSettings.SerializationBinder = new TypeNameSerializationBinder(_assemblies);
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { title = "HRTraining API", version = "v1" });
            //});
            services.AddSwaggerGen();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();
            }, _assemblies);

            services.AddDbContext<AccountContext>();
            services.AddDbContext<ActivityContext>();
            services.AddDbContext<ActivityHistoryContext>();
            services.AddDbContext<ActivityStatisticsContext>();
            services.AddDbContext<DeviceContext>();
            services.AddDbContext<GoalsContext>();
            services.AddDbContext<ProfileContext>();
            services.AddDbContext<TargetContext>();
            services.AddDbContext<WorkoutContext>();
            services.AddDbContext<WorkoutHistoryContext>();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRTraining API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
