import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  user: User | null | undefined;

  constructor(accountService: AccountService) {
    accountService.currentUser$.subscribe({
      next: response => this.user = response
    })
  }
}
