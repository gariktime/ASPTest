import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { UserComponent } from './users/user/user.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { FormsModule} from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule, Routes } from '@angular/router'

import { UserService } from './users/shared/users.service';
import { DepartmentService } from './users/shared/department.service';

const appRoutes : Routes = [
  { path: 'list', component: UserListComponent },
  { path: 'user', component: UserComponent },
  { path: '', redirectTo: '/list', pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserComponent,
    UserListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [UserService, DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
