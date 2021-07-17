using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.ML;
using ClassifierPrototypeML.Model;

namespace ServiceClassifierWEB
{
    public class Startup
    {
        private readonly string _MLPath;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _MLPath = GetAbsolutePath("MLModel.zip");
        }
        public static string GetAbsolutePath(string relative)
        {
            System.IO.FileInfo _dataroot = new System.IO.FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataroot.Directory.FullName;
            string fullpath = System.IO.Path.Combine(assemblyFolderPath, relative);
            return fullpath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddPredictionEnginePool<ModelInput, ModelOutput>().FromFile(_MLPath);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
