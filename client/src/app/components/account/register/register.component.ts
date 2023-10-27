import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { RegisterUser } from 'src/app/models/register-user.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  passowrdsNotMatch: boolean | undefined;
  apiErrorMessage: string | undefined;

  constructor(private accountService: AccountService, private fb: FormBuilder) { }

  //#region FormGroup
  registerFg = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]], // Use / instead of ' around RegEx
    passwordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
    confirmPasswordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]]
  })

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }
  //#endregion FormGroup

  //#region Methods
  register(): void {
    this.apiErrorMessage = undefined;

    if (this.PasswordCtrl.value === this.ConfirmPasswordCtrl.value) {
      this.passowrdsNotMatch = false;

      let user: RegisterUser = {
        email: this.EmailCtrl.value,
        password: this.PasswordCtrl.value,
        confirmPassword: this.ConfirmPasswordCtrl.value
      }

      this.accountService.registerUser(user).subscribe({
        next: user => console.log(user),
        error: err => this.apiErrorMessage = err.error // it might be a list of errors so using a string varialbe is not good!
      })
    }
    else {
      this.passowrdsNotMatch = true;
    }
  }

  getState(): void {
    console.log(this.registerFg);
  }
  //#endregion Methods
}
