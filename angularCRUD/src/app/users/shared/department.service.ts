import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
 
import { Department } from'./department.model'
 
@Injectable()
export class DepartmentService {
  departmentList : Department[];
  constructor(private http : Http) { }

  getDepartmentList(){
    this.http.get('http://localhost:53697/api/departments')
    .map((data : Response) =>{
      return data.json() as Department[];
    }).toPromise().then(x => {
      this.departmentList = x;
    })
  }
}