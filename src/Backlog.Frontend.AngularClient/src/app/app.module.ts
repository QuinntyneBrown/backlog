import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import { LoginModule } from "backlogFrontendAngularLibrary";

import "./rxjs-extensions";

import { AppComponent } from './app.component';
import { HomePageComponent } from "./home";

import {routing} from "./app.routing";


const declarables = [
    AppComponent,
    HomePageComponent
];

const providers = [

];

@NgModule({
    imports: [
        routing,
        LoginModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

