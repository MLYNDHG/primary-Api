﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using RayPI.AuthHelper;
using RayPI.SwaggerHelp;
using Swashbuckle.AspNetCore.Swagger;

namespace RayPI
{
    /// <summary>
    /// 项目启动设置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 项目启动设置
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 运行时调用此方法。使用此方法向容器添加服务。
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            #region  Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",new Info{
                    Version="v1.1.0",
                    Title="Ray WebAPI",
                    Description="框架集合",
                    TermsOfService="None",
                    Contact=new Swashbuckle.AspNetCore.Swagger.Contact {
                        Name="路西菲尔",Email="2674268221@qq.com",Url="http://www.cnblogs.con/RayWang"
                    }
                });               

                //添加服务注释
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath,"APIHelp.xml");
                var Entity = Path.Combine(basePath, "RayPI.Entity.xml");
                c.IncludeXmlComments(xmlPath,true);
                c.IncludeXmlComments(Entity, true);
                //c.DocumentFilter<SwaggerDocTag>();


                //添加header验证信息
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                c.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和下面的AddSecurityDefinition方法指定的
                //方案名称要一致，这里是Bearer
                c.AddSecurityDefinition("Bearer",new ApiKeyScheme {
                    Description= "JWT授权(数据将在请求头中进行传输) 参数结构：\"Authorization:Bearer{token}\"",
                    Name="Authorization",//jwt默认的参数名称
                    In="header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type="apiKey"
                });

            });
            #endregion

            #region
            //缓存
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            //认证
            services.AddAuthorization(options =>
            {
                options.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());
                options.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());
                options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());
            });
            #endregion

            #region CORS跨域
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", policy =>
                {
                    policy.AllowAnyOrigin()//允许任何源
                    .AllowAnyMethod()//允许任何方式
                    .AllowAnyHeader()//允许任何头
                    .AllowCredentials();//允许cookie
                });
                c.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:9090")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("authorization");
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 运行时调用此方法。使用此方法配置HTTP请求管道。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          
            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","ApiHelp V1");
            });
            #endregion

            #region TokenAuth
            app.UseMiddleware<TokenAuth>();
            #endregion

            app.UseMvc();

            app.UseStaticFiles();//用于访问wwwroot下的文件 
        }
    }
}
