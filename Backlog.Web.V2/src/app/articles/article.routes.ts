import { RouteListener, RouterEventHub, routerEventHubEvents, RouterNavigate } from "../router";
import { createElement, Storage } from "../utilities";
import { environment } from "../environment";
import { AuthorizedRouteListener } from "../users";
import { articleActions, ArticleDeleteSelect, ArticleEditSelect} from "./actions";

export class ArticleEditRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("article-edit");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "article-edit") {
            return createElement(`<ce-article-edit article-id='${options.routeParams.id}'></ce-article-edit>`);
        }
        return null;
    }
}

export class ArticleCreateRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("article-create");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "article-create") {
            return createElement("<ce-article-edit></ce-article-edit>");
        }
        return null;
    }
}

export class ArticleViewRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("article-view");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "article-view") {            
            return createElement(`<ce-article-view slug='${options.routeParams.slug}'></ce-article-view>`);
        }
        return null;
    }
}

export class ArticleListRouteListener extends AuthorizedRouteListener {
    constructor(private _routerEventHub: RouterEventHub = RouterEventHub.Instance) {
        super("article-list");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "article-list") {
            return createElement("<ce-article-list></ce-article-list>");
        }
        return null;
    }
}
