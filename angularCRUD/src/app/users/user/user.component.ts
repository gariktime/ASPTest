import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/users.service';
import { DepartmentService } from '../shared/department.service';
import { User } from '../shared/user.model';
import { Department } from '../shared/department.model';
import { ToastrService } from 'ngx-toastr';  

@Component({
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {

  constructor(private userService : UserService, private departmentService: DepartmentService) { }

  ngOnInit() {
    this.departmentService.getDepartmentList();
  }

}
