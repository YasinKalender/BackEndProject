using Autofac;
using Autofac.Extras.DynamicProxy;
using BackEndProject.Business.Caching;
using BackEndProject.Business.Interceptor;
using BackEndProject.Business.Interfaces;
using BackEndProject.Business.JWT;
using BackEndProject.Business.Services;
using BackEndProject.DAL.Context;
using BackEndProject.DAL.Repositories;
using BackEndProject.DAL.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.IOC
{
    public class DependencyResolvers : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
            builder.RegisterGeneric(typeof(BaseManager<>)).As(typeof(IBaseService<>));

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<TokenService>().As<ITokenService>();
            builder.RegisterType<CacheManager>().As<ICacheService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector=new AspectInterceptorSelector()


                }).SingleInstance();
         
            
        }

    }
}
