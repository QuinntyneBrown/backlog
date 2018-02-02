import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./article-item.component.html",
    styleUrls: ["./article-item.component.css"],
    selector: "ce-article-item"
})
export class ArticleItemComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
