import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/users.service';
import { User } from '../shared/user.model';
import { ToastrService } from 'ngx-toastr';  
import * as $ from 'jquery';


@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {

  constructor(private userService : UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.userService.getUserList();
  }
  
  onSelect(user: User){
    $(document).ready(function(){
      $(".clickable-row").click(function(){
        console.log('123');
        $(".clickable-row").removeClass("highlight");
        $(this).addClass("highlight");
        // if($(this).hasClass("highlight"))
        //     $(this).removeClass('highlight');
        // else
        //     $(this).addClass('highlight').siblings().removeClass('highlight');
      })
    });

    this.userService.selectedUserId = user.Id;
    console.log("SelectedId: ", user.Id);
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
