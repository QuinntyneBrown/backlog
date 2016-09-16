import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';

import { PageHeaderComponent } from "./page-header.component";
import { PageFooterComponent } from "./page-footer.component";
import { OneColumnLayoutComponent } from "./one-column-layout.component";

import { EpicEditFormComponent } from "./epic-edit-form.component";
import { EpicListComponent } from "./epic-list.component";



const declarables = [
    PageHeaderComponent,
    PageFooterComponent,
    OneColumnLayoutComponent,

    EpicEditFormComponent,
    EpicListComponent
];

const providers = [];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ComponentsModule { }
