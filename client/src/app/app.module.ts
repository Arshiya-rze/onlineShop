import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MaterialModule } from './modules/material.module';
import { ComponentModule } from './modules/component.module';

@NgModule({
  declarations: [
    AppComponent, // do NOT move it
  ],
  imports: [
    BrowserModule, // do NOT move it
    AppRoutingModule,
    BrowserAnimationsModule,

    ComponentModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
