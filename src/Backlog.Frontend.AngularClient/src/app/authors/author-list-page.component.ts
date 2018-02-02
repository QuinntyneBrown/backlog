import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { AuthorsService } from "./authors.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";

@Component({
    templateUrl: "./author-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./author-list-page.component.css"
    ],
    selector: "ce-author-list-page"
})
export class AuthorListPageComponent { 
    constructor(
        private _router: Router,
        private _authorsService: AuthorsService) { }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/authors/edit/${$event.author.id}`);
    }

    public handleDeleteClick($event) {
        this._authorsService.remove({ author: $event.author })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.authors, value: $event.author.id });
    }

    public ngOnInit() {
        this._authorsService.get()
            .takeUntil(this._ngUnsubscribe)
            .map(data => this.authors = data.authors)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public authors: Array<any> = [];
}
