import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ArticlesService } from "./articles.service";
import { Article } from "./article.model";
import { FormControl } from "@angular/forms";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./article-edit-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "../shared/components/page.css",
        "./article-edit-page.component.css"
    ],
    selector: "ce-article-edit-page"
})
export class ArticleEditPageComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _articlesService: ArticlesService,
        private _router: Router
    ) {
        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .filter(params => params["id"] != null)
            .switchMap(params => this._articlesService.getById({ id: params["id"] }))
            .map(x => this.article = x.article)
            .do(() => {        
                this.nameFormControl.setValue(this.article.name);
            })
            .subscribe();
    }

    public ngAfterViewInit() {
        this.nameFormControl.patchValue(this.article.name);
    }

    public tryToSave() {
        const article: Partial<Article> = {
            id: this.article.id,
            name: this.nameFormControl.value,
        };
        
        this._articlesService.addOrUpdate({article})
            .do(() => this._router.navigateByUrl("/articles/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    public tryToRemove() {
        this._articlesService.remove({ article: this.article })
            .do(() => this._router.navigateByUrl("/articles/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
        this._ngUnsubscribe.next();     
    }

    
    public nameFormControl: FormControl = new FormControl('');

    public article: Partial<Article> = {};
}
