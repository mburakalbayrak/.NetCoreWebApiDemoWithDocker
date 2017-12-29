using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurriyet.HurriyetDb.Business.Abstract;
using Hurriyet.HurriyetDb.Business.Concrete;
using Hurriyet.HurriyetDb.DataAccess.Abstract;
using Hurriyet.HurriyetDb.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hurriyet.HurriyetDb.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Birgün entitiyFrameworkCore'dan vazgeçersem EfProductDal ve EfUserDal'ı değiştirmem yeterli olacak.
            // yada farklı bir manager kullanmak istersem onları da buradan değiştirerek ilerleyebilirim.

            // AddScoped, AddSingleton, AddTransient arasında farklar var. Singleton adı üzerinde her kullanıcı için tek bir manager instance'ı oluşturur.
            //AddScoped ve AddTransient arasındaki farkı şekil üzerinde açıklamam daha kolay olacaktır. 
            //Fakat ikiside birbirine çok benziyor. Farkları ise yapılan her request için bir request içinde birden fazla aynı nesneye ihtiyacı da olsa scopedta aynı requestte tek instance alınırken transientte birden fazla instance olusturulur

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<IUSerService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddMvc();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidAudience = "heimdall.fabrikam.com",
                            ValidateIssuer = true,
                            ValidIssuer = "west-world.fabrikam.com",
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    "Benden bir security key istiyor sanırım şifreleme anahtarı için"))
                        };
                        options.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = ctx =>
                            {
                                //Gerekirse burada gelen token içerisindeki çeşitli bilgilere göre doğrulam yapılabilir.
                                return Task.CompletedTask;
                            },
                            OnAuthenticationFailed = ctx =>
                            {
                                Console.WriteLine("Exception:{0}", ctx.Exception.Message);
                                return Task.CompletedTask;
                            }
                        };
                    }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc();
        }
    }
}
