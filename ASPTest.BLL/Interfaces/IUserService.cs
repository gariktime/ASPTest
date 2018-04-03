using ASPTest.BLL.DTO;
using ASPTest.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        OperationDetails AddUser(UserDTO userDTO);

        UserDTO FindUser(int id);

        List<UserDTO> GetUsers();
    }
}
