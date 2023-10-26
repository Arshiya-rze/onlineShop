import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegisterUser } from 'src/app/models/register-user.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  constructor(private accountService: AccountService, private fb: FormBuilder) {}

  registerFg = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern('^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$')]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
    confirmPasswordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]]
  })

  register(): void {

    let user: RegisterUser = {
      email: 'a3@a.com',
      password: 'aaaaaaa',
      confirmPassword: 'aaaaaaa'
    }

    this.accountService.registerUser(user).subscribe({
      next: user => console.log(user)
    })
  }
}
