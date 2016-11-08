import { AuthorizedRouteListener } from "../users";

export class ProductListRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("product-list");
    }
    
    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return options.nextRouteName == "product-list" ? document.createElement("ce-product-list") : null;
    }    
}
