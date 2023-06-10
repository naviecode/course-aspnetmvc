using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using ASP.NET_CORE_MVC.Services;
using System.Net;
using Microsoft.AspNetCore.Http;
using ASP.NET_CORE_MVC.ExtendMethods;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
namespace ASP.NET_CORE_MVC
{
    public class Startup
    {
        public static string ContentRootPath{get;set;}
        public Startup(IConfiguration configuration,  IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
             services.AddRazorPages();
            // services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
            
            //thiết lập đường dẫn khi không tìm thấy file thì sẽ tìm trong myview
            services.Configure<RazorViewEngineOptions>(options =>{
                // /View/Controller/Action.cshtml
                // /MyView/Controller/Action.cshtml

                // {0} -> tean action
                // {1}-> ten controller
                // {2} -> ten area
                options.ViewLocationFormats.Add("/MyView/{1}/{0}"+ RazorViewEngine.ViewExtension);
            });

            // services.AddSingleton<ProductServices>();
            // services.AddSingleton<ProductServices, ProductServices>();
            // services.AddSingleton(typeof(ProductServices));
            services.AddSingleton(typeof(ProductServices), typeof(ProductServices));
            services.AddSingleton<PlanetSerivce>();
        
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

            //Tạo thêm phương thức mở rộng cho IApplicationBuilder trong thư mục ExtendMethods
            app.AddStatusCodePage();
            

            app.UseRouting();

            app.UseAuthentication(); //xác định danh tính
            app.UseAuthorization();//xác thực quyền truy cập

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapRazorPages();
                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Home}/{action=Index}/{id?}");

                // /sayhi
                endpoints.MapGet("/sayhi", async(context)=>{
                    await context.Response.WriteAsync($"Hello Asp.net MVC - {DateTime.Now}");
                });

                // endpoints.MapControllers
                // endpoints.MapControllerRoute
                // endpoints.MapDefaultControllerRoute
                // endpoints.MapAreaControllerRoute

                // [AcceotVerbs]
                // [Route]
                // [HttpGet]
                // [HttpPost]
                // [HttpPut]
                // [HttpDelete]
                // [HttpPatch]

                //Area

                endpoints.MapControllers();



                //Thực hiện trên các controller không có area
                endpoints.MapControllerRoute(
                    name : "first",
                    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
                    defaults: new {
                        controller= "First",
                        action= "ViewProduct"
                    },
                    constraints: new{
                        // url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
                        // id = new RangeRouteConstraint(2,4)
                    }


                );

                endpoints.MapAreaControllerRoute(
                    name:"product",
                    pattern: "/{controller}/{action=Index}/{Id?}",
                    areaName : "ProductManage"
                );

                //Các ràng buộc trong endpoints
                // IRouteConstraint
                // url = "xemsanpham" //~ new StringRouteConstraint("xemsanpham)
                //URL = start-here/Tencontroller/Action/id
                //controller =>
                //action =>
                //area =>
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"/{controller=Home}/{action=Index}/{Id?}" //start-here, start-here/1
                    // defaults: new {  
                    //     controller = "First",
                    //     action = "ViewProduct",
                    //     id = 3
                    // }
                );

                
                endpoints.MapRazorPages();
            });
        }
    }
}
