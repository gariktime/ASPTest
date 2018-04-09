import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
 
import { User } from'./user.model'
import { Department } from'./department.model'
 
@Injectable()
export class UserService {
  selectedUserId: number;
  selectedUser : User;
  userList : User[];
  constructor(private http : Http) { }

  addUser(user : User){
    var body = JSON.stringify(user);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post('http://localhost:53697/api/users',body,requestOptions).map(x => x.json());
  }

  editUser(id, user) {
    var body = JSON.stringify(user);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('http://localhost:53697/api/users/' + id, body, requestOptions).map(res => res.json());
  }

  getUserList(){
    this.http.get('http://localhost:53697/api/users')
    .map((data : Response) =>{
      return data.json() as User[];
    }).toPromise().then(x => {
      this.userList = x;
    })
  }

  deleteUser(id: number) {
    return this.http.delete('http://localhost:53697/api/users/' + id).map(res => res.json());
  }
}