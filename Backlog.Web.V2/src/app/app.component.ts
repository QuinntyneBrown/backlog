import { Http } from "./utilities";
import { AppRouterOutletComponent } from "./app-router-outlet.component";

let template = require("./app.component.html");
let styles = require("./app.component.scss");

export class AppComponent extends HTMLElement {    
    connectedCallback() {

        var p = fetch("");
        this.innerHTML = `<style>${styles}</style>${template}`;
        this.routerOutlet = new AppRouterOutletComponent(this.routerOutletElement);
    }    

    routerOutlet: AppRouterOutletComponent;
    get routerOutletElement() { return this.querySelector(".router-outlet") as HTMLElement; }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define(`ce-app`, AppComponent));