using ASPTest.BLL.DTO;
using ASPTest.BLL.Interfaces;
using ASPTest.BLL.Util;
using ASPTest.DAL.Entities;
using ASPTest.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork db;

        public UserService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void AddUser(UserDTO userDTO)
        {
            User user = null;
        }

        public UserDTO FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetUsers()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            return Mapper.Map<List<User>, List<UserDTO>>(db.Users.GetUsers());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
