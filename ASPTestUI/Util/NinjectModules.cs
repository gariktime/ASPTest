using ASPTest.BLL.Interfaces;
using ASPTest.BLL.Services;
using Ninject.Modules;

namespace ASPTestUI.Util
{
    public class NinjectModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IDepartmentService>().To<DepartmentService>();
        }
    }
}