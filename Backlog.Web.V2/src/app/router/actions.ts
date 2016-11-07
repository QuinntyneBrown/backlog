export var routerActions = {
    LINK_CLICK: "[Router] Link Click",
    ROUTE_CHANGED: "[Router] Route Changed"
};

export class RouterNavigate extends CustomEvent {
    constructor(routeSegments: Array<string>) {
        super(routerActions.LINK_CLICK, {
            detail: {
                routeSegments: routeSegments
            }
        });
    }
}

export class RouteChanged extends CustomEvent {
    constructor(options: any) {        
        super(routerActions.ROUTE_CHANGED, {
            detail: {
                options: options
            }
        });
    }
}