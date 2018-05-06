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
        /// Редактирование
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationDetails EditUser(UserDTO userDTO)
        {
            using (var transaction = db.UsersDatabase.BeginTransaction())
            {
                try
                {
                    User user = Mapper.Map<UserDTO, User>(userDTO);
                    user.UserName = userDTO.UserName;
                    user.DepartmentId = userDTO.DepartmentId;
                    db.Users.Edit(user);
                    db.Users.Save();
                    transaction.Commit();
                    return new OperationDetails(true, "Редактирование успешно завершено");
                }
                catch
                {
                    transaction.Rollback();
                    return new OperationDetails(false, "Ошибка при редактировании пользователя");
                }
            }
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationDetails DeleteUser(int id)
        {
            using (var transaction = db.UsersDatabase.BeginTransaction())
            {
                try
                {
                    User user = db.Users.FindById(id);
                    if (user != null)
                    {
                        db.Users.Delete(id);
                        db.Users.Save();
                        transaction.Commit();
                        return new OperationDetails(true, "Пользователь успешно добавлен");
                    }
                    else
                        return new OperationDetails(false, "Ошибка при удалении пользователя");
                }
                catch
                {
                    transaction.Rollback();
                    return new OperationDetails(false, "Ошибка при удалении пользователя");
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
            List<User> users = db.Users.GetUsers().ToList();
            List<Department> departments = db.Departments.GetDepartments().ToList();

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

            return Mapper.Map<List<User>, List<UserDTO>>(userswithdeps);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
