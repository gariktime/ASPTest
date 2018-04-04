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

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationDetails AddUser(UserDTO userDTO)
        {
            using (var transaction = db.UsersDatabase.BeginTransaction())
            {
                try
                {
                    Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
                    User user = Mapper.Map<UserDTO, User>(userDTO);
                    db.Users.Add(user);
                    db.Users.Save();
                    transaction.Commit();
                    return new OperationDetails(true, "Пользователь успешно добавлен");
                }
                catch
                {
                    transaction.Rollback();
                    return new OperationDetails(false, "Ошибка при добавлении пользователя");
                }
            }
        }

        /// <summary>
        /// Поиск пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO FindUser(int id)
        {
            User user = db.Users.FindById(id);
            if (user != null)
            {
                Department department = db.Departments.FindById(id);
                user.Department = department;
                Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
                return Mapper.Map<User, UserDTO>(db.Users.FindById(id));
            }
            else
                return null;
        }

        /// <summary>
        /// Список всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> GetUsers()
        {
            IEnumerable<User> users = db.Users.GetUsers();
            IEnumerable<Department> departments = db.Departments.GetDepartments();

            List<User> userswithdeps = users.Join(departments,
                                                c => c.DepartmentId,
                                                d => d.Id,
                                                (c, d) => new User
                                                {
                                                    Id = c.Id,
                                                    UserName = c.UserName,
                                                    DepartmentId = c.DepartmentId,
                                                    Department = new Department() { Id = d.Id, Title = d.Title }
                                                }).ToList();

            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            return Mapper.Map<List<User>, List<UserDTO>>(userswithdeps);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
