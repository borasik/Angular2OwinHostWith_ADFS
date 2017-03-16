import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './app.login.component';

const appRoutes: Routes = [
    { path: '', component: AppComponent }
];

@NgModule({
    imports: [BrowserModule, RouterModule.forRoot(appRoutes) ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
