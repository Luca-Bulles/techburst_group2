using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.BLL;
using Interfaces.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using techburst_BLL;
using techburst_BLL.Collections;
using techburst_BLL.Models;
using techburst_DAL.Handler;
using techburst_Data_Access_Layer.Handler;
using techburst_Interface.Handler_Interfaces;

namespace techburst_group2
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.LogoutPath = "/User/Logout";
                options.ClaimsIssuer = "/User/Login";
                options.AccessDeniedPath = "/User/Login";
            });
            services.AddControllersWithViews();


            services.AddScoped<IDBConnectionHandler, DBConnectionHandler>();

            services.AddScoped<IArticleHandler, ArticleHandler>();
            services.AddScoped<IArticleCollection, ArticleCollection>();
            services.AddScoped<IArticleModel, ArticleModel>();

            services.AddScoped<ITagHandler, TagHandler>();
            services.AddScoped<ITagCollection, TagCollection>();
            services.AddScoped<ITagModel, TagModel>();
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<ContactCollection, ContactCollection>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //ArticleHandler.SetConnectionString(ConnectionString);
            //ArticleHandler articleHandler = new ArticleHandler(ConnectionString);
        }
    }
    
}
