import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  user: User | null | undefined;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
      this.accountService.currentUser$.subscribe({
        next: responce => this.user = responce
      })
  }

  logOut(): void {
    this.accountService.logoutUser();
  }
}
