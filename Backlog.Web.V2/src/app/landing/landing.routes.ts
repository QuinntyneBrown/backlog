import { RouteListener } from "../router";
import { createElement, Storage } from "../utilities";
import { environment } from "../environment";
import { AuthorizedRouteListener } from "../users";

export class LandingRouteListener extends AuthorizedRouteListener {
    constructor() {
        super("landing");
    }

    public onViewTransition(options: RouteChangeOptions): HTMLElement {
        if (options.nextRouteName == "landing") {
            return createElement("<ce-landing></ce-landing>");
        }
        return null;
    }
}