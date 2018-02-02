import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AuthorsService } from "./authors.service";
import { Author } from "./author.model";
import { FormControl } from "@angular/forms";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./author-edit-page.component.html",
    styleUrls: [
        "../shared/components/forms.css",
        "../shared/components/page.css",
        "./author-edit-page.component.css"
    ],
    selector: "ce-author-edit-page"
})
export class AuthorEditPageComponent {
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _authorsService: AuthorsService,
        private _router: Router
    ) {
        this._activatedRoute.params
            .takeUntil(this._ngUnsubscribe)
            .filter(params => params["id"] != null)
            .switchMap(params => this._authorsService.getById({ id: params["id"] }))
            .map(x => this.author = x.author)
            .do(() => {        
                this.nameFormControl.setValue(this.author.name);
            })
            .subscribe();
    }

    public ngAfterViewInit() {
        this.nameFormControl.patchValue(this.author.name);
    }

    public tryToSave() {
        const author: Partial<Author> = {
            id: this.author.id,
            name: this.nameFormControl.value,
        };
        
        this._authorsService.addOrUpdate({author})
            .do(() => this._router.navigateByUrl("/authors/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    public tryToRemove() {
        this._authorsService.remove({ author: this.author })
            .do(() => this._router.navigateByUrl("/authors/list"))
            .takeUntil(this._ngUnsubscribe)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
        this._ngUnsubscribe.next();     
    }

    
    public nameFormControl: FormControl = new FormControl('');

    public author: Partial<Author> = {};
}
