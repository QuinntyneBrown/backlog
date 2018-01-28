import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";

import { HeaderComponent } from "./components";
import { QuillTextEditorComponent } from "./components/quill-text-editor.component";

import { Storage, StorageFactory } from "./services";
import { RedirectService } from "./services/redirect.service";
import { AuthGuardService } from "./services";
import { TenantInterceptor } from "./interceptors";
import { AuthInterceptor } from "./interceptors";
import { PopoverService, PopoverServiceFactory } from "./services/popover.service";
import { Position } from "./services/position";
import { Ruler } from "./services/ruler";
import { Space } from "./services/space";
import { ModalService, ModalServiceFactory } from "./services/modal.service";

import { DropDownMenuItemComponent } from "./components";
import { DropDownMenuComponent } from "./components";
import { CircularButtonComponent } from "./components";
import { BackdropComponent } from "./components";
import { DigitalAssetInputUrlComponent } from "./components/digital-asset-input-url.component";

const customElements = [
    DropDownMenuComponent,
    DropDownMenuItemComponent,
    BackdropComponent
];

const declarables = [
    HeaderComponent,
    QuillTextEditorComponent,
    CircularButtonComponent,
    DigitalAssetInputUrlComponent
];

const providers = [
    Ruler,
    Space,
    {
        provide: Storage,
        useFactory: StorageFactory
    },
    {
        provide: ModalService,
        useFactory: ModalServiceFactory
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
