import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { HomePageComponent } from "./home-page.component";
import { PublicMasterPageComponent } from "./public-master-page.component";
import { PublicHeaderComponent } from "./public-header.component";

import { ApiService } from "./api.service";

const ROUTES: Routes = [
    {
        path: '',
        component: PublicMasterPageComponent,
        children: [
            {
                path:'',
                component: HomePageComponent
            }
        ]
    }
];

const declarations = [
    HomePageComponent,
    PublicMasterPageComponent,
    PublicHeaderComponent
];

const providers = [ApiService];

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES),
        SharedModule
    ],
    declarations,
    providers,
    exports: declarations
})
export class PublicModule {}