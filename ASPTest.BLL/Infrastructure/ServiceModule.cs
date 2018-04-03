using ASPTest.DAL.Interfaces;
using ASPTest.DAL.Repositories;
using Ninject.Modules;

namespace ASPTest.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string userDbConStr;
        private string departmentDbConStr;

        public ServiceModule(string userDbCS, string depDbCS)
        {
            userDbConStr = userDbCS;
            departmentDbConStr = depDbCS;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("userDbConStr", userDbConStr)
                                                .WithConstructorArgument("depDbConStr", departmentDbConStr);
        }
    }
}
