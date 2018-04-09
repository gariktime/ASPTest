using ASPTest.BLL.DTO;
using ASPTest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ASPTest.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DepartmentsController : ApiController
    {
        private IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService depServ)
        {
            departmentService = depServ;
        }

        // GET /api/departments
        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            List<DepartmentDTO> departments = departmentService.GetDepartments();
            return departments;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                departmentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
