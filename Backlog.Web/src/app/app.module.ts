import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import "./rxjs-extensions";

import { AppComponent } from './app.component';

import { ActionsModule } from "./actions";
import { ComponentsModule } from "./components";
import { HelpersModule } from "./helpers";
import { PipesModule } from "./pipes";
import { ServicesModule } from "./services";
import { StoreModule } from "./store";

import {
    RoutingModule,
    routedComponents
} from "./routing";

const declarables = [
    AppComponent,
    ...routedComponents
];

const providers = [

];

@NgModule({
    imports: [
        ActionsModule,
        ComponentsModule,
        HelpersModule,
		PipesModule,
        RoutingModule,
        ServicesModule,
        StoreModule,

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

