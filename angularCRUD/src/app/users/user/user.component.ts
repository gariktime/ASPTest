import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/users.service';
import { DepartmentService } from '../shared/department.service';
import { User } from '../shared/user.model';
import { Department } from '../shared/department.model';
import { ToastrService } from 'ngx-toastr';  
import * as $ from 'jquery';

@Component({
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {

  constructor(private userService : UserService, private departmentService: DepartmentService) { }

  ngOnInit() {
    this.departmentService.getDepartmentList();
    if (this.userService.selectedUserId != null)
    {
      //this.userService.selectedUser = this.userService.
    }
    else
    {
      this.userService.selectedUser = {
        Id: null,
        UserName: '',
        DepartmentId: 1
      }
      $(document).ready(function(){
        $("#departmentSelect option[value=1]").prop("selected", true)
      });
    }
  }

  addUser(user: User){

  }

  editUser(user: User){

  }
}
