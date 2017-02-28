import { Http } from "./utilities";
import { AppRouterOutletComponent } from "./app-router-outlet.component";

const template = require("./app.component.html");
const styles = require("./app.component.scss");

export class AppComponent extends HTMLElement {  

    constructor() {
        super();
    }  

    connectedCallback() {                
        this.innerHTML = `<style>${styles}</style>${template}`;
        this.routerOutlet = new AppRouterOutletComponent(this.routerOutletElement);
    }    

    routerOutlet: AppRouterOutletComponent;
    get routerOutletElement() { return this.querySelector(".router-outlet") as HTMLElement; }
}

customElements.define(`ce-app`, AppComponent);