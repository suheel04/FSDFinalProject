import { Component, OnInit } from '@angular/core';
import {  UserService } from '../shared/user.service';
import { User } from '../shared/user.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css'],
  providers: [UserService]
})
export class AddUserComponent implements OnInit {
  errorMessage = '';
  _userFilter = '';
  get userFilter(): string {
    return this._userFilter;
  }
  set userFilter(value: string) {
    this._userFilter = value;
    this.filterdUser = this._userFilter ? this.performFilter(this._userFilter) : this.users;
  }

  userToAdd : User;  
  filterdUser: User[] = [];
  users: User[] = [];


  constructor(private userService : UserService,
    private route: ActivatedRoute,
    private router:Router,
    ) { 
      this.userToAdd = new User();
      
  }

  ngOnInit() {    

    this.GetUsers();
  }


  performFilter(filterBy: any): User[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.users.filter((usr: User) =>
    usr.FirstName.toLocaleLowerCase().indexOf(this._userFilter) !== -1  
    ||usr.LastName.toLocaleLowerCase().indexOf(this._userFilter) !== -1    
        
    );
  }
  
  GetUsers(){
    this.userService.getAllUsers().subscribe(
      rp=>
      {
        this.users = rp;
        this.filterdUser = rp;
      },
      error => this.errorMessage = <any>error
      );
  }
  onClickSubmit(myForm: NgForm){   
    if(this.userToAdd.UserID <= 0)
    {
      this.userService.createUser(this.userToAdd).subscribe(data=>{
        this.GetUsers();     
        alert('User added successfully');
        this.userToAdd = new User();
        myForm.resetForm();
      });
    }  
    else{
      this.userService.updateUser(this.userToAdd).subscribe(data=>{
        this.GetUsers();
        alert('User updated successfully');
        this.userToAdd = new User();       
        myForm.resetForm();
    });
    
    
  }
}
  onSort(id: number){   
    switch (id) {
      case 1:
        this.filterdUser = this.filterdUser.sort((x,y)=> x.FirstName.localeCompare(y.FirstName));
        break;
      case 2:
      this.filterdUser = this.filterdUser.sort((x,y)=> x.LastName.localeCompare(y.LastName));
        break;
      case 3:
      this.filterdUser = this.filterdUser.sort((x,y)=>x.EmployeeID-y.EmployeeID);
        break;    
      default:
        break;
    }
  }

  Edit(editUser: User){   
    this.userToAdd =editUser;
  }
  Reset(myForm: NgForm)
  {
    this.userToAdd= new User();
    this.GetUsers();
    myForm.resetForm();
  }

  Delete(userToDelete : User) : void{
    this.userService.Delete(userToDelete.UserID).subscribe(data=>{
     alert('User deleted successfully');
     this.GetUsers();
     this.performFilter('update');
    console.log(data)});
    
  }
    

}
