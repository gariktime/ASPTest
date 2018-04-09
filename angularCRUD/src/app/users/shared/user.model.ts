import { Department } from'./department.model'

export class User{
    constructor(
        public Id?: number,
        public UserName?: string,
        public DepartmentId?: number,
        public Department?: Department){}
}