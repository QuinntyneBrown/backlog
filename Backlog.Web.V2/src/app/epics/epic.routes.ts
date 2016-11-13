import { RouteListener, RouterEventHub, routerEventHubEvents, RouterNavigate } from "../router";
import { createElement, Storage } from "../utilities";
import { environment } from "../environment";
import { AuthorizedRouteListener } from "../users";
import { epicActions, EpicDeleteSelect, EpicEditSelect} from "./actions";

export class EpicEditRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("epic-edit");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {

        if (options.nextRouteName == "epic-edit") {

            return createElement(`<ce-epic-edit epic-id='${options.routeParams.id}'></ce-epic-edit>`);
        }
        return null;
    }
}

export class EpicViewRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("epic-view");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "epic-view") {            
            return createElement(`<ce-epic-view epic-id='${options.routeParams.id}'></ce-epic-view>`);
        }
        return null;
    }
}

export class EpicCreateRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("epic-create");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "epic-create") {
            return createElement("<ce-epic-edit></ce-epic-edit>");
        }
        return null;
    }
}

export class EpicListRouteListener extends AuthorizedRouteListener {
    constructor(private _routerEventHub: RouterEventHub = RouterEventHub.Instance) {
        super("epic-list");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "epic-list") {
            return createElement("<ce-epic-list></ce-epic-list>");
        }
        return null;
    }
}
