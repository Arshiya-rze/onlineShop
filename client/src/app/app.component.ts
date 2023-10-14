import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
// import { User } from './models/user.model';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  // users: User[] | undefined;

  constructor(private http: HttpClient, private accountService: AccountService, private fb: FormBuilder) {

  }

  // ngOnInit(): void {
    // this.registerFg;
  // }

  // showUsers(): void {
    // this.http.get<User[]>('https://localhost:5001/api/use').subscribe({
    //   next: (response: User[]) => {
    //     console.log(response);
    //     this.users = response;
    //   },
    //   error: err => console.log(err.message)
    // });

    // this.accountService.getUsers().subscribe({
    //   next: (response: User[]) => {
    //     console.log(response);
    //     this.users = response;
    //   }
    // });
  // }


  // registerFg = this.fb.group({
  //   emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]],
  //   passwordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
  //   confirmPasswordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
  // });

  // get EmailCtrl(): FormControl {
  //   return this.registerFg.get('emailCtrl') as FormControl;
  // }
  // get PasswordCtrl(): FormControl {
  //   return this.registerFg.get('passwordCtrl') as FormControl;
  // }
  // get ConfirmPassword(): FormControl {
  //   return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  // }

  // registerUser(): void {
  //   let user: User = {
  //     email: this.EmailCtrl.value,
  //     password: this.PasswordCtrl.value,
  //     confirmPassword: this.ConfirmPassword.value
  //   }

  //   this.http.post('https://localhost:5001/api/account/register', user).subscribe({
  //     next: user => {
  //       console.log(user);
  //     },
  //     error: err => console.log(err)
  //   });
  // }
}
