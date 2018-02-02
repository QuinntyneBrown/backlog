import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { ArticlesService } from "./articles.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";

@Component({
    templateUrl: "./article-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./article-list-page.component.css"
    ],
    selector: "ce-article-list-page"
})
export class ArticleListPageComponent { 
    constructor(
        private _router: Router,
        private _articlesService: ArticlesService) { }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/articles/edit/${$event.article.id}`);
    }

    public handleDeleteClick($event) {
        this._articlesService.remove({ article: $event.article })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.articles, value: $event.article.id });
    }

    public ngOnInit() {
        this._articlesService.get()
            .takeUntil(this._ngUnsubscribe)
            .map(data => this.articles = data.articles)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public articles: Array<any> = [];
}
