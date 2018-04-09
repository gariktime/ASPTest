using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }

        public UserDTO()
        {

        }
    }
}
