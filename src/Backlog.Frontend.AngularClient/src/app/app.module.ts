import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import {TenantsModule} from "./tenants/tenants.module";
import {SharedModule} from "./shared/shared.module";
import { LoginModule } from "./login/login.module";

import "./rxjs-extensions";

import { AppComponent } from './app.component';
import { AppShellComponent } from "./app-shell.component";

import {routing} from "./app-routing.module";


const declarables = [
    AppComponent,
    AppShellComponent
];

const providers = [

];

@NgModule({
    imports: [
        routing,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule,
        TenantsModule,
        SharedModule        
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

