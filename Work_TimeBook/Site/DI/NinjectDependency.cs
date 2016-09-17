﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Ninject;

namespace Site.DI
{
    public class NinjectDependency:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependency()
        {
            this.kernel = new StandardKernel();
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
            kernel.Bind<IUserinfoRepos>().To<UserinfoRepos>();
        }
    }
}