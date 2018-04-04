using ASPTest.BLL.DTO;
using ASPTest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ASPTest.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService userService;
        private IDepartmentService departmentService;

        public UsersController(IUserService userServ, IDepartmentService depServ)
        {
            userService = userServ;
            departmentService = depServ;
        }

        // GET /api/users
        [ResponseType(typeof(List<UserDTO>))]
        public IHttpActionResult GetUsers()
        {
            List<UserDTO> users = userService.GetUsers();
            return Ok(users);
        }

        // GET /api/users/5
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult GetUser(int id)
        {
            UserDTO user = userService.FindUser(id);
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService.Dispose();
                departmentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
