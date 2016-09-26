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
import { SideNavMenuComponent } from "./side-nav-menu.component";

import { EpicEditFormComponent } from "./epic-edit-form.component";
import { EpicListComponent } from "./epic-list.component";
import { StoryEditFormComponent } from "./story-edit-form.component";
import { StoryListComponent } from "./story-list.component";
import { StoryDetailComponent } from "./story-detail.component";
import { EditorComponent } from "./editor.component";
import { ReusableStoryGroupEditFormComponent } from "./reusable-story-group-edit-form.component";
import { ReusableStoryGroupListComponent } from "./reusable-story-group-list.component";
import { ProjectEditFormComponent } from "./project-edit-form.component";
import { ProjectListComponent } from "./project-list.component";


const declarables = [
    PageHeaderComponent,
    PageFooterComponent,
    OneColumnLayoutComponent,
    HtmlTextareaComponent,
    EditorComponent,
    DigitalAssetUploadComponent,
    SideNavMenuComponent,

    EpicEditFormComponent,
    EpicListComponent,

    StoryEditFormComponent,
    StoryListComponent,
    StoryDetailComponent,

    ReusableStoryGroupEditFormComponent,
    ReusableStoryGroupListComponent,

    ProjectEditFormComponent,
    ProjectListComponent
];

const providers = [];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule, PipesModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ComponentsModule { }
