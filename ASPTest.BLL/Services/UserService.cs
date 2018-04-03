using ASPTest.BLL.DTO;
using ASPTest.BLL.Infrastructure;
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

        public OperationDetails AddUser(UserDTO userDTO)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
                User user = Mapper.Map<UserDTO, User>(userDTO);
                db.Users.Add(user);
                return new OperationDetails(true, "Пользователь успешно добавлен");
            }
            catch
            {
                return new OperationDetails(false, "Ошибка при добавлении пользователя");
            }
        }

        public UserDTO FindUser(int id)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            return Mapper.Map<User, UserDTO>(db.Users.FindById(id));
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
