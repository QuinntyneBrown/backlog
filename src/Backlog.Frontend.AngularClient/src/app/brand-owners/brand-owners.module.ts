import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { BrandOwnersService } from "./brand-owners.service";
import { BrandOwnerEditPageComponent } from "./brand-owner-edit-page.component";
import { BrandOwnerListPageComponent } from "./brand-owner-list-page.component";
import { BrandOwnerItemComponent } from "./brand-owner-item.component";

const declarables = [
    BrandOwnerItemComponent,
    BrandOwnerEditPageComponent,
    BrandOwnerListPageComponent
];

const providers = [
    BrandOwnersService
];

const ROUTES: Routes = [
    { path: '', redirectTo: 'list', pathMatch: 'full' },
    {
        path: 'list',
        component: BrandOwnerListPageComponent
    },
    {
        path: 'edit/:id',
        component: BrandOwnerEditPageComponent
    },
    {
        path: 'create',
        component: BrandOwnerEditPageComponent
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
export class BrandOwnersModule { }
