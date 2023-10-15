import { Component } from '@angular/core';
import { User } from './models/user.model';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  // users: User[] | undefined;

  allUsers: User[] | undefined;
  constructor(private userService: UserService) { }

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
