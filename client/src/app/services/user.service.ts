import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { Observable, map } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private accountService: AccountService) { }

  getAllUsers(): Observable<User[] | null> {
    return this.http.get<User[]>('http://localhost:5000/api/user').pipe(
      map((users: User[]) => {
        if (users)
        {
          return users;
        }

        return null;
      })
    )
  }

  getUsersById(): Observable<User | null> {
    return this.http.get<User>('http://localhost:5000/api/user').pipe(
      map((user: User | null) => {
        if (user)
        {
          return user;
        }

        return null;
      })
    )
  }
}
