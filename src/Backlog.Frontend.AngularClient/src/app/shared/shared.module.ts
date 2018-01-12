import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";

import { HeaderComponent } from "./components";

import { Storage, StorageFactory } from "./services";
import { RedirectService } from "./services/redirect.service";
import { AuthGuardService } from "./services";
import { TenantInterceptor } from "./interceptors";
import { AuthInterceptor } from "./interceptors";
import { PopoverService, PopoverServiceFactory } from "./services/popover.service";
import { Position } from "./services/position";
import { Ruler } from "./services/ruler";
import { Space } from "./services/space";

const declarables = [
    HeaderComponent
];

const providers = [
    Ruler,
    Space,
    {
        provide: Storage,
        useFactory: StorageFactory
    },
    RedirectService,
    AuthGuardService,
    Position,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: TenantInterceptor,
        multi: true
    },
    {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true
    },
    {
        provide: PopoverService,
        useFactory: PopoverServiceFactory,
        deps: [Position]
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, HttpClientModule, ReactiveFormsModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class SharedModule { }
