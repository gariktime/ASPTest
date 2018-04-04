using ASPTest.BLL.Interfaces;
using ASPTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork db;

        public DepartmentService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
