using ASPTest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        void Add(Department department);

        Department FindById(int id);

        IEnumerable<Department> GetDepartments();

        void Save();
    }
}
