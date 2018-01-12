import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { SetTenantShellComponent } from "./set-tenant-shell.component";
import { TenantsService } from "./tenants.service";
import { TenantGuardService } from "./tenant-guard.service";

const ROUTES: Array<any> = [
    {
        path: "set",
        component: SetTenantShellComponent
    }
];

const declarables = [
    SetTenantShellComponent
];

const providers = [
    TenantsService,
    TenantGuardService
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
export class TenantsModule { }
