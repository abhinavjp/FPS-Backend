using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using FPS.Service.Repository.Service;
using FPS.Service.Repository.Interface;
using StructureMap.Pipeline;
using FPS.Service.Interface;
using FPS.Service.Services;

namespace FPS.Service.Infrastructure
{
    public static class StructureMapConfigurator
    {
        private static Container container = new Container();
        private static bool isInitialized = false;

        private static void Configure()
        {
            container.Configure(x =>
            {
                // Repository
                x.For(typeof(IUnitOfWork<>)).Use(typeof(UnitOfWork<>));
                x.For(typeof(IGenericRepository<,>)).Use(typeof(GenericRepository<,>));

                // Services
                x.For<IResidentService>().Use<ResidentService>();
                x.For<IApartmentService>().Use<ApartmentService>();
            });
            isInitialized = true;
        }

        public static T GetInstance<T>()
        {
            if (!isInitialized)
            {
                Configure();
            }
            return container.GetInstance<T>();
        }

        public static T GetInstance<T>(ExplicitArguments args)
        {
            if (!isInitialized)
            {
                Configure();
            }
            return container.GetInstance<T>(args);
        }
    }
}
