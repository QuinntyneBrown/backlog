import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { StoriesService } from "./stories.service";
import { StoryEditPageComponent } from "./story-edit-page.component";
import { StoryListPageComponent } from "./story-list-page.component";
import { StoryItemComponent } from "./story-item.component";

const declarables = [
    StoryItemComponent,
    StoryEditPageComponent,
    StoryListPageComponent
];

const providers = [
    StoriesService
];

const ROUTES: Routes = [
    { path: '', redirectTo: 'list', pathMatch: 'full' },
    {
        path: 'list',
        component: StoryListPageComponent
    },
    {
        path: 'edit/:id',
        component: StoryEditPageComponent
    },
    {
        path: 'create',
        component: StoryEditPageComponent
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
export class StoriesModule { }
