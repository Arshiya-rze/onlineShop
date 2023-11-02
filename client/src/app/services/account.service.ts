import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../models/user.model';
import { RegisterUser } from '../models/register-user.model';
import { LoginUser } from '../models/login-user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  registerUser(userInput: RegisterUser): Observable<User> {
    return this.http.post<User>('https://localhost:5001/api/account/register', userInput).pipe(
      map(userResponse => {
        // if (userResponse) {
          this.currentUserSource.next(userResponse);
          // this.setCurrentUser(userResponse);

          return userResponse;
        // }

        // return null;
      })
    );
  }

  loginUser(userInput: LoginUser): Observable<User> {
    return this.http.post<User>('https://localhost:5001/api/account/login', userInput).pipe(
      map(userResponse => {
        // if (userResponse) {
          this.currentUserSource.next(userResponse);
          // this.setCurrentUser(userResponse);

          return userResponse;
        // }

        // return null;
      })
    );
  }

  // setCurrentUser(user: User): void {
  //   localStorage.setItem('user', JSON.stringify(user));

  //   this.currentUserSource.next(user);
  // }


  // logoutUser(): void {
  //   localStorage.removeItem('user');

  //   this.currentUserSource.next(null);
  //   this.router.navigate(['/login'])
  // }

}
