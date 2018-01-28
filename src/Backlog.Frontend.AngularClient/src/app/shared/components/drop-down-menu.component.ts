import { render, html, TemplateResult } from "lit-html";

export const dropDownMenuEvents = {
    DROP_DOWN_MENU_ITEM_CLICK: "[DROP DOWN MENU ITEM] CLICK"
};

export class DropDownMenuItemComponent extends HTMLElement {
    constructor() {
        super();
        this.handleClick = this.handleClick.bind(this);
    }

    public connectedCallback() {
        if (!this.shadowRoot) this.attachShadow({ mode: 'open' });

        this.render(html`
            <style>
                :host {
                    display:inline-block;
                    line-height:3em;
                    cursor:pointer;
                    width:100%;
                    max-width:calc(100% - 30px);
                    padding:0px 15px;
                    user-select:none;
                }

                :host(:hover) {
                    background-color:rgb(241,241,241);
                }
            </style>                
            <slot></slot>
        `);

        this.addEventListener("click", this.handleClick);
    }

    public render(templateResult: TemplateResult) {
        render(templateResult, this.shadowRoot);
    }

    public handleClick() {
        document.dispatchEvent(new CustomEvent(dropDownMenuEvents.DROP_DOWN_MENU_ITEM_CLICK, {
            cancelable: false,
            bubbles: true,
            scoped: true,
            detail: {
                url: this.getAttribute("[routerLink]")
            }
        }));
    }
}

export class DropDownMenuComponent extends HTMLElement {
    constructor() {
        super();
    }

    public connectedCallback() {
        if (!this.shadowRoot) this.attachShadow({ mode: 'open' });
        this.render(html`
            <style>
                :host {
                    background-color: #fff;
                    display:grid;
                    padding: 10px 0px;
                    font-weight:575;
                    font-size:0.85em;
                    border-radius:3.5px;
                    border:1px solid rgb(200,200,200);
                    width:285px;
                    box-shadow: 0px 0px 10px 0px rgba(0,0,0,0.25);
                }

                ul, li {
                    margin:0;
                    padding:0;
                }

                li {
                    list-style:none;
                }
            </style>
            <section>
                <ul>
                    <li><ce-drop-down-menu-item [routerLink]="/dashboard">Dashboard</ce-drop-down-menu-item></li>
                    <li><ce-drop-down-menu-item [routerLink]="/users/edit/1">Edit User</ce-drop-down-menu-item></li>
                    <li><ce-drop-down-menu-item [routerLink]="/login">Sign out</ce-drop-down-menu-item></li>                    
                </ul>
            </section>
        `);
    }

    public render(templateResult: TemplateResult) {
        render(templateResult, this.shadowRoot);
    }
}
customElements.define('ce-drop-down-menu-item', DropDownMenuItemComponent);
customElements.define(`ce-drop-down-menu`, DropDownMenuComponent);