import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { RegisterUser } from 'src/app/models/register-user.model';
import { AccountService } from 'src/app/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  passwordsNotMatch: boolean | undefined;
  apiErrorMessage: string | undefined;

  constructor(private accountService: AccountService, private fb: FormBuilder, private router: Router) { }

  // #region formGroup
  registerFg = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
    confirmPasswordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]]
  })

  //neveshtan get haye Fg
  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }
  
  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }
  //#endregion

  // #region methods
  register(): void {
    this.apiErrorMessage =  undefined;

    if (this.PasswordCtrl.value == this.ConfirmPasswordCtrl.value){
      this.passwordsNotMatch = false;

      let user: RegisterUser = {
        email: this.EmailCtrl.value,
        password: this.PasswordCtrl.value,
        confirmPassword: this.ConfirmPasswordCtrl.value
      }

      //return observable<user>
      this.accountService.registerUser(user).subscribe({
        next: user => {
          console.log(user);
          this.router.navigateByUrl('/'); 
        },
        error: err => this.apiErrorMessage = err.error
      })
    }
    else {
      this.passwordsNotMatch = true;
    }
  }

  getState(): void {
    console.log(this.registerFg);
  }
}