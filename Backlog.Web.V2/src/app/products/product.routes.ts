import { AuthorizedRouteListener } from "../users";

export class ProductListRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("product-list");
    }
    
    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return options.nextRouteName == "product-list" ? document.createElement("ce-product-list") : null;
    }    
}

export class ProductCreateRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("product-create");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return options.nextRouteName == "product-create" ? document.createElement("ce-product-edit") : null;
    }
}

export class ProductEditRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("product-edit");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        return options.nextRouteName == "product-edit" ? document.createElement("ce-product-edit") : null;
    }
}
