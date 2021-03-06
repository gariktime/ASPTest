﻿using ASPTest.BLL.DTO;
using ASPTest.BLL.Infrastructure;
using ASPTest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace ASPTest.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private IUserService userService;
        private IDepartmentService departmentService;

        public UsersController(IUserService userServ, IDepartmentService depServ)
        {
            userService = userServ;
            departmentService = depServ;
        }

        // POST api/users
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult AddUser(UserDTO userDTO)
        {
            userService.AddUser(userDTO);
            return CreatedAtRoute("DefaultApi", new { id = userDTO.Id }, userDTO);
        }

        // PUT api/users/5
        [HttpPut]
        public IHttpActionResult EditUser(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
                return BadRequest();

            OperationDetails od = userService.EditUser(userDTO);
            if (od.Succeeded == false)
                return NotFound();
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/users/5
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            UserDTO user = userService.FindUser(id);
            if (user == null)
                return NotFound();
            OperationDetails od = userService.DeleteUser(id);
            if (od.Succeeded == false)
                return BadRequest();
            else
                return Ok(user);
        }

        // GET /api/users/5
        public UserDTO GetUser(int id)
        {
            UserDTO user = userService.FindUser(id);
            return user;
        }

        // GET /api/users
        public IEnumerable<UserDTO> GetUsers()
        {
            List<UserDTO> users = userService.GetUsers();
            return users;
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
