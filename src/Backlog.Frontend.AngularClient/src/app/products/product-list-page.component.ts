import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";
import { ProductsService } from "./products.service";
import { Router } from "@angular/router";
import { pluckOut } from "../shared/utilities/pluck-out";

@Component({
    templateUrl: "./product-list-page.component.html",
    styleUrls: [
        "../shared/components/page.css",
        "./product-list-page.component.css"
    ],
    selector: "ce-product-list-page"
})
export class ProductListPageComponent { 
    constructor(
        private _router: Router,
        private _productsService: ProductsService) { }

    public handleEditClick($event) {        
        this._router.navigateByUrl(`/products/edit/${$event.product.id}`);
    }

    public handleDeleteClick($event) {
        this._productsService.remove({ product: $event.product })
            .takeUntil(this._ngUnsubscribe)
            .subscribe();

        pluckOut({ items: this.products, value: $event.product.id });
    }

    public ngOnInit() {
        this._productsService.get()
            .takeUntil(this._ngUnsubscribe)
            .map(data => this.products = data.products)
            .subscribe();
    }

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }

    public products: Array<any> = [];
}
