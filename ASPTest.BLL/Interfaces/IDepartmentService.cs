using ASPTest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.Interfaces
{
    public interface IDepartmentService : IDisposable
    {
        List<DepartmentDTO> GetDepartments();
    }
}
