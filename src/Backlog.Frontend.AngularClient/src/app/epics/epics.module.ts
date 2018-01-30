import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { EpicsService } from "./epics.service";
import { EpicEditPageComponent } from "./epic-edit-page.component";
import { EpicListPageComponent } from "./epic-list-page.component";
import { EpicItemComponent } from "./epic-item.component";

const declarables = [
    EpicItemComponent,
    EpicEditPageComponent,
    EpicListPageComponent
];

const providers = [
    EpicsService
];

const ROUTES: Routes = [
    { path: '', redirectTo: 'list', pathMatch: 'full' },
    {
        path: 'list',
        component: EpicListPageComponent
    },
    {
        path: 'edit/:id',
        component: EpicEditPageComponent
    },
    {
        path: 'create',
        component: EpicEditPageComponent
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
export class EpicsModule { }
