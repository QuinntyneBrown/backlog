import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { ArticlesService } from "./articles.service";
import { ArticleEditPageComponent } from "./article-edit-page.component";
import { ArticleListPageComponent } from "./article-list-page.component";
import { ArticleItemComponent } from "./article-item.component";

const declarables = [
    ArticleItemComponent,
    ArticleEditPageComponent,
    ArticleListPageComponent
];

const providers = [
    ArticlesService
];

const ROUTES: Routes = [
    { path: '', redirectTo: 'list', pathMatch: 'full' },
    {
        path: 'list',
        component: ArticleListPageComponent
    },
    {
        path: 'edit/:id',
        component: ArticleEditPageComponent
    },
    {
        path: 'create',
        component: ArticleEditPageComponent
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
export class ArticlesModule { }
