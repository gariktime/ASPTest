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

        OperationDetails EditUser(UserDTO userDTO);

        OperationDetails DeleteUser(int id);

        UserDTO FindUser(int id);

        List<UserDTO> GetUsers();
    }
}
