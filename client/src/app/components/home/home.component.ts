import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  allUsers: User[] | undefined;
  user: User | null | undefined;

  constructor(private userService: UserService, accountService: AccountService) {
    accountService.currentUser$.subscribe({
      next: res => this.user = res
    })
  }

  showAllUsers() {
    this.userService.getAllUsers().subscribe({
      next: users => this.allUsers = users,
      error: err => console.log(err)
    });
  }
}
