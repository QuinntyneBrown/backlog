import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';

import { PageHeaderComponent } from "./page-header.component";
import { PageFooterComponent } from "./page-footer.component";
import { OneColumnLayoutComponent } from "./one-column-layout.component";

import { EpicEditFormComponent } from "./epic-edit-form.component";
import { EpicListComponent } from "./epic-list.component";
import { StoryEditComponent } from "./story-edit.component";
import { StoryListComponent } from "./story-list.component";


const declarables = [
    PageHeaderComponent,
    PageFooterComponent,
    OneColumnLayoutComponent,

    EpicEditFormComponent,
    EpicListComponent,

    StoryEditComponent,
    StoryListComponent
];

const providers = [];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ComponentsModule { }
