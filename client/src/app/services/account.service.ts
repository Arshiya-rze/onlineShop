import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { User } from '../models/user.model';
import { RegisterUser } from '../models/register-user.model';
import { LoginUser } from '../models/login-user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  registerUser(userInput: RegisterUser): Observable<User> {
    return this.http.post<User>('https://localhost:5001/api/account/register', userInput).pipe(
      map(user => user)
    );
  }

  loginUser(userInput: LoginUser): Observable<User>{
    return this.http.post<User>('https://localhost:5001/api/account/login', userInput).pipe(
      map(user => user)
    );
  }

  // getUsers(): Observable<User[]> {
  //   return this.http.get<User[]>('https://localhost:5001/api/user').pipe(
  //     map(response => {return response})
  //   )
  // }
}
