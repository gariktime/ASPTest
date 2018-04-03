using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        System.Data.Entity.Database UsersDatabase { get; }
        System.Data.Entity.Database DepartmentsDatabase { get; }

        IUserRepository Users { get; }

        IDepartmentRepository Departments { get; }
    }
}
