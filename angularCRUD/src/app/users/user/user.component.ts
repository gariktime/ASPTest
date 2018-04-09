import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/users.service';
import { DepartmentService } from '../shared/department.service';
import { User } from '../shared/user.model';
import { Department } from '../shared/department.model';
import { ToastrService } from 'ngx-toastr';  
import { NgForm } from '@angular/forms'
import { Router } from '@angular/router'
import * as $ from 'jquery';

@Component({
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {

  constructor(private userService : UserService, private departmentService: DepartmentService, 
    private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.departmentService.getDepartmentList();

    $(document).ready(function(){
      $("#departmentSelect option[value=1]").prop("selected", true)
    });
  }

  onSubmit(form: NgForm){
    if (this.userService.selectedUserId == null) { //добавление пользователя
      this.userService.addUser(this.userService.selectedUser)
        .subscribe(data => {
          this.toastr.success('User added successfully', 'User');
          this.router.navigate(['/list']);
        })
      }
    else { //редактирование существующего
      this.userService.editUser(this.userService.selectedUserId, this.userService.selectedUser)
        .subscribe(data => {
          this.toastr.info('User modified successfully', 'User');
          this.router.navigate(['/list']);
        }
      );
    }
  }

  resetForm(form?: NgForm){
    if (form != null)
      form.reset();
    this.userService.selectedUser = {
      Id: null,
      UserName: '',
      DepartmentId: 1
    }
  }
}
