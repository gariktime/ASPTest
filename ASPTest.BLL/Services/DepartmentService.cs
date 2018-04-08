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
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork db;

        public DepartmentService(IUnitOfWork uow)
        {
            db = uow;
        }

        public List<DepartmentDTO> GetDepartments()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            return Mapper.Map<List<Department>, List<DepartmentDTO>>(db.Departments.GetDepartments().ToList());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
