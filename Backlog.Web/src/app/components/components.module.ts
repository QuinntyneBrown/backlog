import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';
import { PipesModule } from "../pipes";

import { PageHeaderComponent } from "./page-header.component";
import { PageFooterComponent } from "./page-footer.component";
import { OneColumnLayoutComponent } from "./one-column-layout.component";
import { HtmlTextareaComponent } from "./html-textarea.component";
import { DigitalAssetUploadComponent } from "./digital-asset-upload.component";

import { EpicEditFormComponent } from "./epic-edit-form.component";
import { EpicListComponent } from "./epic-list.component";
import { StoryEditFormComponent } from "./story-edit-form.component";
import { StoryListComponent } from "./story-list.component";
import { StoryDetailComponent } from "./story-detail.component";
import { EditorComponent } from "./editor.component";

const declarables = [
    PageHeaderComponent,
    PageFooterComponent,
    OneColumnLayoutComponent,
    HtmlTextareaComponent,
    EditorComponent,
    DigitalAssetUploadComponent,

    EpicEditFormComponent,
    EpicListComponent,

    StoryEditFormComponent,
    StoryListComponent,
    StoryDetailComponent
];

const providers = [];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule, PipesModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ComponentsModule { }
