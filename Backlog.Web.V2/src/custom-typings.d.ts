interface ModernWindow {
    customElements: any;
}

interface Window extends ModernWindow { }

interface RouteChangeOptions {
    currentView: HTMLElement;
    nextRouteName: string;
    previousRouteName: string;
    routeParams: any;
    cancelled: any;
}

declare var Quill;

declare var rome: any;