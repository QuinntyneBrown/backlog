import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { UserEditPageComponent } from "./user-edit-page.component";
import { UsersService } from "./users.service";

export const USER_ROUTES: Routes = [
    {
        path: 'edit/current',
        component: UserEditPageComponent
    },
    {
        path: 'edit/:id',
        component: UserEditPageComponent
    }
];

const declarables = [
    UserEditPageComponent
];

const providers = [
    UsersService
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forChild(USER_ROUTES),
        SharedModule
    ],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class UsersModule { }
