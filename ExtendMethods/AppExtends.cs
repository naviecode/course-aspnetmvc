using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ASP.NET_CORE_MVC.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            //custom trang lỗi trả về 400 - 500
            app.UseStatusCodePages(appError=>{
                appError.Run(async context=>{
                    var respone = context.Response;
                    var code = respone.StatusCode;
                    
                    var content = @$"<html>
                        <head>
                            <meta charset='UTF-8' />
                            <title>Lỗi {code}</title>
                        </head>
                        <body>
                            <p>
                                Có lỗi xảy ra {code} - {(HttpStatusCode)code}
                            </p>
                        </body>
                    </html>";
                    await respone.WriteAsync(content);
                });
            }); //Code 400 - 500 trả về trang error khi kh truy cập được
        }
    }
}