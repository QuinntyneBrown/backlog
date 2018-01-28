import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { SignUpMasterPageComponent } from "./sign-up-master-page.component";

const declarables = [
    SignUpMasterPageComponent
];

const providers = [];

const ROUTES: Array<any> = [
    {
        path: '',
        component: SignUpMasterPageComponent
    }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES),
        SharedModule
    ],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class SignUpModule { }
