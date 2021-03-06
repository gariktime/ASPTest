﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.BLL.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<UserDTO> Users { get; set; }

        public DepartmentDTO()
        {
            Users = new List<UserDTO>();
        }
    }
}
