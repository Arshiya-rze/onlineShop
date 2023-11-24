import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './Components/main/main.component';
import { RegisterComponent } from './Components/account/register/register.component';
import { LoginComponent } from './Components/account/login/login.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { NoAccessComponent } from './Components/no-access/no-access.component';

const routes: Routes = [
  {path: '', component: MainComponent},
  {path: 'home', component: MainComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'no-access', component: NoAccessComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
