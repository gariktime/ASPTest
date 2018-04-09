import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/users.service';
import { User } from '../shared/user.model';
import { ToastrService } from 'ngx-toastr';  

@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {

  constructor(private userService : UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.userService.getUserList();
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?') == true) {
      this.userService.deleteUser(id)
      .subscribe(x => {
        this.userService.getUserList();
        this.toastr.warning("Deleted Successfully","Employee Register");
      })
    }
  }
}
