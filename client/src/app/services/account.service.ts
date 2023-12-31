import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../models/user.model';
import { RegisterUser } from '../models/register-user.model';
import { LoginUser } from '../models/login-user.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  registerUser(userInput: RegisterUser): Observable<User | null> {
    return this.http.post<User>('http://localhost:5000/api/account/register', userInput).pipe(
      map(userResponce => {
        if (userResponce)
        {
          this.setCurrentUser(userResponce);

          this.router.navigateByUrl('/');

          return userResponce;
        }

        return null;
      })
    );
  }

  loginUser(userInput: LoginUser): Observable<User | null> {
    return this.http.post<User>('http://localhost:5000/api/account/login', userInput).pipe(
      map(userResponce => {
        if (userResponce)
        {
            this.setCurrentUser(userResponce);

            return userResponce;
        }

        return null;
      })
    );
  }

  setCurrentUser(user: User): void {
    this.currentUserSource.next(user);

    localStorage.setItem('user', JSON.stringify(user));
  }

  logoutUser(): void {
    this.currentUserSource.next(null);

    localStorage.removeItem('user');

    this.router.navigateByUrl('/');
  }
}
