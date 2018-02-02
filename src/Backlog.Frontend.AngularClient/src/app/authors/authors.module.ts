import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { AuthorsService } from "./authors.service";
import { AuthorEditPageComponent } from "./author-edit-page.component";
import { AuthorListPageComponent } from "./author-list-page.component";
import { AuthorItemComponent } from "./author-item.component";

const declarables = [
    AuthorItemComponent,
    AuthorEditPageComponent,
    AuthorListPageComponent
];

const providers = [
    AuthorsService
];

const ROUTES: Routes = [
    { path: '', redirectTo: 'list', pathMatch: 'full' },
    {
        path: 'list',
        component: AuthorListPageComponent
    },
    {
        path: 'edit/:id',
        component: AuthorEditPageComponent
    },
    {
        path: 'create',
        component: AuthorEditPageComponent
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
export class AuthorsModule { }
