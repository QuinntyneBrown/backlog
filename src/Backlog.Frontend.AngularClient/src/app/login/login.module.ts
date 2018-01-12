import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";

import { LoginComponent } from "./login.component";
import { LoginShellComponent } from "./login-shell.component";

const declarables = [
    LoginComponent,
    LoginShellComponent
];

const providers = [];

const ROUTES: Array<any> = [
    {
        path: '',
        component: LoginShellComponent
    }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES)
    ],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class LoginModule { }
