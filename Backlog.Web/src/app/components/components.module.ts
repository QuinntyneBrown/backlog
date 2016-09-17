import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';

import { PageHeaderComponent } from "./page-header.component";
import { PageFooterComponent } from "./page-footer.component";
import { OneColumnLayoutComponent } from "./one-column-layout.component";
import { HtmlTextareaComponent } from "./html-textarea.component";

import { EpicEditFormComponent } from "./epic-edit-form.component";
import { EpicListComponent } from "./epic-list.component";
import { StoryEditFormComponent } from "./story-edit-form.component";
import { StoryListComponent } from "./story-list.component";


const declarables = [
    PageHeaderComponent,
    PageFooterComponent,
    OneColumnLayoutComponent,
    HtmlTextareaComponent,

    EpicEditFormComponent,
    EpicListComponent,

    StoryEditFormComponent,
    StoryListComponent
];

const providers = [];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ComponentsModule { }
