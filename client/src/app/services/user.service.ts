import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable, delay, map, take } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private accountService: AccountService) { }

  // Observable / Promise
  getAllUsers(): Observable<User[] | null> {

    //#region Create requestOptions like headers for each and every http-request
    // let requestOptions; // Type is not declared since options can vary. see this page
    // https://angular.io/api/common/http/HttpClient

    // this.accountService.currentUser$.pipe(take(1)).subscribe({
    //   next: (currentUser: User | null) => {
    //     if (currentUser) {
    //       requestOptions = {
    //         headers: new HttpHeaders({ 'Authorization': `Bearer ${currentUser.token}` })
    //       }
    //     }
    //   }
    // });

    // return this.http.get<User[]>('https://localhost:5001/api/user', requestOptions).pipe(
    //#endregion

    return this.http.get<User[]>('https://localhost:5001/api/user').pipe(
      map((users: User[]) => {
        if (users)
          return users;

        return null;
      })
    )
  }

  getUserById(): Observable<User | null> {
    return this.http.get<User>('https://localhost:5001/api/user/10923849128437912').pipe(
      map((user: User | null) => {
        if (user)
          return user;

        return null;
      })
    )
  }
}
