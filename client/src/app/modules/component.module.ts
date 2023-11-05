import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { LoginComponent } from '../components/account/login/login.component';
import { RegisterComponent } from '../components/account/register/register.component';
import { HomeComponent } from '../components/home/home.component';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { NoAccessComponent } from '../components/no-access/no-access.component';
import { NotFoundComponent } from '../components/not-found/not-found.component';
import { MaterialModule } from './material.module';

const components = [ // vari-able
  NotFoundComponent,
  NoAccessComponent,
  NavbarComponent,
  LoginComponent,
  RegisterComponent,
  HomeComponent
];

@NgModule({
  declarations: [
    components
  ],
  imports: [
    CommonModule,

    AppRoutingModule, // also in app.module.ts
    BrowserAnimationsModule, // also in app.module.ts
    FormsModule, // Remove from app.module.ts
    ReactiveFormsModule, // Remove from in app.module.ts
    HttpClientModule, // Remove from in app.module.ts
    MaterialModule // Remove from in app.module.ts
  ],
  exports: [
    components
  ]
})
export class ComponentModule {
  constructor() { }
}
