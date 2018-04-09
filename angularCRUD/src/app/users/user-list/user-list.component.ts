import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/users.service';
import { User } from '../shared/user.model';
import { ToastrService } from 'ngx-toastr';  
import { Router } from '@angular/router'
import * as $ from 'jquery';

@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {

  constructor(private userService : UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.userService.getUserList();
  }
  
  addUser(){
    this.userService.selectedUserId = null;
    this.userService.selectedUser = {
      Id: null,
      UserName: '',
      DepartmentId: 1
    }
    this.router.navigate(['/user']);
  }

  editUser(){
    if (this.userService.selectedUserId != null){
      this.userService.selectedUser = this.userService.userList.filter(x => x.Id == this.userService.selectedUserId)[0];
      this.router.navigate(['/user']);
    }
  }

  onSelect(user: User){
    $(document).ready(function(){
      $(".clickable-row").click(function(){
        $(".clickable-row").removeClass("highlight");
        $(this).addClass("highlight");
      })
    });

    this.userService.selectedUserId = user.Id;
  }

  onDelete() {
    var id = this.userService.selectedUserId;
    if (id != null) {
      if (confirm('Are you sure to delete this record ?') == true) {
        this.userService.deleteUser(id)
        .subscribe(x => {
          this.userService.getUserList();
          this.toastr.warning('User deleted successfully', 'User');
        })
      }
    }
  }
}
