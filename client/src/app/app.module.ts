import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// // CRUD
import { HttpClientModule } from '@angular/common/http';

// // Form
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

// // Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar'; 
import {MatIconModule} from '@angular/material/icon'; 

// Components
import { NotFoundComponent } from './components/not-found/not-found.component';
import { NoAccessComponent } from './components/no-access/no-access.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { HomeComponent } from './components/home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    NoAccessComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    // // CRUD
    HttpClientModule,

    // // Form
    FormsModule,
    ReactiveFormsModule,

    // // Material
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
