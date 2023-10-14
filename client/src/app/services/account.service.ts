import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
// import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  // constructor(private http: HttpClient) { }

  // getUsers(): Observable<User[]> {
  //   return this.http.get<User[]>('https://localhost:5001/api/user').pipe(
  //     map(response => {return response})
  //   )
  // }
}
