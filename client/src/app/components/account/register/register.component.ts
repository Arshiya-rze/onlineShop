import { Component } from '@angular/core';
import { RegisterUser } from 'src/app/models/register-user.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  constructor(private accountService: AccountService) {}

  register(): void {
    let userInput: RegisterUser = {
      email: 'a4@a.com',
      password: 'aaaaaaa',
      confirmPassword: 'aaaaaaa'
    }

    this.accountService.registerUser(userInput).subscribe({
      next: user => console.log(user)
    })
  }
}
