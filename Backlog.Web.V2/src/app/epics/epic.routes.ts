import { RouteListener, RouterEventHub, routerEventHubEvents, RouterNavigate } from "../router";
import { createElement, Store } from "../utilities";
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

    public beforeViewTransition(options: RouteChangeOptions) {
        if (options.previousRouteName == "epic-list") {
            (options.currentView as HTMLElement).removeEventListener(epicActions.SELECT, this.onEditSelect.bind(this));
        }
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "epic-list") {
            return createElement("<ce-epic-list></ce-epic-list>");
        }
        return null;
    }

    public afterViewTransition(options: RouteChangeOptions) {
        if (options.nextRouteName == "epic-list") {
            (options.currentView as HTMLElement).addEventListener(epicActions.SELECT, this.onEditSelect.bind(this));
        }
    }

    public onEditSelect(e: EpicEditSelect) {
        this._routerEventHub.dispatch(routerEventHubEvents.NAVIGATE, new RouterNavigate(["epic", "edit", e.detail.epicId]));
    }
}
