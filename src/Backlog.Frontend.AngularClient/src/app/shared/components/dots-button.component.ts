import { html, TemplateResult, render } from "lit-html";
import { repeat } from "lit-html/lib/repeat";
import { unsafeHTML } from "../../../../node_modules/lit-html/lib/unsafe-html.js";

const styles = unsafeHTML(`<style>${require("./dots-button.component.css")}<style>`);

export class DotsButtonComponent extends HTMLElement {
    constructor() {
        super();
    }
    
    connectedCallback() {     

        this.attachShadow({ mode: 'open' });
        
		render(this.template, this.shadowRoot);

        if (!this.hasAttribute('role'))
            this.setAttribute('role', 'dotsbutton');
    }

    get template(): TemplateResult {
        return html`
            ${styles}
            &#8226;&#8226;&#8226;
        `;
    }    
}

customElements.define(`ce-dots-button`,DotsButtonComponent);
