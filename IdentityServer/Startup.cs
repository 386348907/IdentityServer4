
using IdentityServer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;

namespace IdentityServer
{
    public class Startup
    {

        private IConfiguration Configuration { get; set; }




        public Startup(IConfiguration _IConfiguration)
        {
            Configuration = _IConfiguration;


        }

        //public IWebHostEnvironment Environment { get; }

        //public Startup(IWebHostEnvironment environment)
        //{
        //    Environment = environment;
        //}

        public void ConfigureServices(IServiceCollection services)
        {

            var DBLink = Configuration["UserDatas:DBLink"];

            var dbBuilder = new DbContextOptionsBuilder().UseSqlServer(DBLink);
 
            var DbContext = new IdentityServerDbContext(dbBuilder.Options);

            //services.AddSingleton(DbContext);
           
           services.AddDbContext<IdentityServerDbContext>(option=> {
               option.UseSqlServer(DBLink);
           });


            //F1 引用IdentityServer 服务 
            //AddIdentityServer 会将 IdentityServer 注册到 DI
            //。他还会注册一个基于内存存储的运行时状态，
            //这对于开发场景来说是很有用的。对于生产环境你就需要像数据库或缓存这些持久化或共享存储部件。
            services.AddIdentityServer()

                .AddDeveloperSigningCredential()

                ///////F4  注入APi和Client
                //注入ApiResources   根据我们的config类进行创建APi  资源
 
                .AddInMemoryApiResources(Config.GetApiResources(DbContext))

                //注入客户端    根据config类配置的信息进行创建客户端   使用时请求需要指定客户端进行对应的授权   不同的客户端可以配置不同的权限
                .AddInMemoryClients(Config.GetClient(DbContext))

                .AddTestUsers(Config.GetUsers(DbContext));//注册测试用户

            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //F2 插入中间件
            app.UseIdentityServer();

        }
    }
}
