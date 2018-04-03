using ASPTest.DAL.EF;
using ASPTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserContext userContext;
        private DepartmentContext departmentContext;

        private IUserRepository userRepository;
        private IDepartmentRepository departmentRepository;

        public UnitOfWork(string userDbConStr, string depDbConStr)
        {
            userContext = new UserContext(userDbConStr);
            departmentContext = new DepartmentContext(depDbConStr);
            userRepository = new UserRepository(userContext, departmentContext);
            departmentRepository = new DepartmentRepository(departmentContext);
        }

        public IUserRepository Users
        {
            get { return userRepository; }
        }

        public IDepartmentRepository Departments
        {
            get { return departmentRepository; }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                    //userRepository.Dispose();
                    //departmentRepository.Dispose();
                    userContext.Dispose();
                    departmentContext.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~UnitOfWork() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
