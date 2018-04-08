using ASPTest.BLL.Interfaces;
using ASPTest.BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ASPTest.WebAPI.Util
{
    //public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    //{
    //    private readonly IKernel kernel;

    //    public NinjectDependencyResolver(IKernel kernel)
    //        : base(kernel)
    //    {
    //        this.kernel = kernel;
    //    }

    //    public IDependencyScope BeginScope()
    //    {
    //        return new NinjectDependencyScope(this.kernel.BeginBlock());
    //    }
    //}

    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
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

        public void AddBindings()
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();
        }
    }
}