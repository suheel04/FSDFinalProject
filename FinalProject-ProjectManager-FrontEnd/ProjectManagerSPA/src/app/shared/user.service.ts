import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseURL: string = 'http://localhost:53262/api/UserManager/';
  constructor(private http: HttpClient) { }

  getAllUsers(): any {
    return this.http.get<User[]>(this.baseURL + 'GetUser');
  }

  getUserById(userID: number): Observable<User> {
    return this.http.get<User>(this.baseURL + 'GetUser/?userID=' + userID);
  }

  createUser(userData: User) {
    console.log(JSON.stringify(userData));
    return this.http.post(this.baseURL, userData);
  }

  updateUser(userData: User) {
    console.log();

    return this.http.put(this.baseURL + 'UpdateUser/', userData);
  }
  Delete(userID: number) {
    console.log("Delete task");
    return this.http.get(this.baseURL + 'DeleteUser/?deleteID=' + userID);
  }



}

