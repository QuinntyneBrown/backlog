import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { HomePageEditPageComponent } from "./home-page-edit-page.component";
import { HomePagesService } from "./home-pages.service";
import { DigitalAssetsModule } from "../digital-assets/digital-assets.module";

const declarations = [
    HomePageEditPageComponent
];

const providers = [
    HomePagesService
];

const ROUTES: Routes = [
    {
        path: '',
        component: HomePageEditPageComponent
    }
];

@NgModule({
    declarations,
    providers,
    exports: declarations,
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES),
        SharedModule,
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HomePagesModule { }