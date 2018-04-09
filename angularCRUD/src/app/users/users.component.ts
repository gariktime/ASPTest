import { Component, OnInit } from '@angular/core';
import { UserService } from './shared/users.service';
import { DepartmentService } from './shared/department.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService, DepartmentService]
})
export class UsersComponent implements OnInit {

  constructor(private userService : UserService, private departmentService: DepartmentService) { }

  ngOnInit() {
  }

}
