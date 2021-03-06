﻿using Mvc5App.Domain.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5App.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IManagerRepository>().To<ManagerRepository>();
            kernel.Bind<AppDbContext>().To<AppDbContext>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}