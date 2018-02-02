import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import {TenantsModule} from "./tenants/tenants.module";
import {SharedModule} from "./shared/shared.module";
import {LoginModule} from "./login/login.module";
import {PageNotFoundComponent} from "./page-not-found.component";

import "./rxjs-extensions";

import { AppComponent } from './app.component';
import { AppMasterPageComponent } from "./app-master-page.component";

import { routing } from "./app-routing.module";
import { constants } from "./shared/constants";

const declarations = [
    AppComponent,
    AppMasterPageComponent,
    PageNotFoundComponent
];

const providers = [
    { provide: constants.BASE_URL, useValue: "" },
    { provide: constants.DEFAULT_PATH, useValue: "/dashboard" }
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
    providers,
    declarations,
    exports: [declarations],
    bootstrap: [AppComponent]
})
export class AppModule { }

