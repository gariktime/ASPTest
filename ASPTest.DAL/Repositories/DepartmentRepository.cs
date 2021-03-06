﻿using ASPTest.DAL.EF;
using ASPTest.DAL.Entities;
using ASPTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public UserContext userDb = null;
        public DepartmentContext depDb = null;

        public DepartmentRepository(DepartmentContext departmentContext)
        {
            depDb = departmentContext;
        }

        public void Add(Department department)
        {
            depDb.Departments.Add(department);
        }

        public Department FindById(int id)
        {
            return depDb.Departments.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Department> GetDepartments()
        {
            return depDb.Departments.AsNoTracking().AsQueryable();
        }

        public void Save()
        {
            depDb.SaveChanges();
        }
    }
}
