let template = require("./tabs.component.html");
let styles = require("./tabs.component.scss");

export class TabsComponent extends HTMLElement {
    connectedCallback() {
        let titles = this.titleElements;
        let panels = this.panelElements;
        this.innerHTML = `<style>${styles}</style> ${template}`;

        titles.forEach(el => this.tabsContainer.appendChild(el));
        panels.map(el => this.panelsContainer.appendChild(el));

        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this.selected = 0;
        this.titleElements[0].classList.add("selected");
    }

    private _addEventListeners() {
        this.titleElements.map(el => el.addEventListener("click", this.onTitleClick.bind(this)));
    }

    disconnectedCallback() {
        this.titleElements.map(el => el.removeEventListener("click", this.onTitleClick.bind(this)));
    }

    onTitleClick(e: any) {
        this.titleElements.map(el => el.classList.remove("selected"));
        e.currentTarget.classList.add("selected");
        this._selectTab(this.titleElements.indexOf(e.currentTarget));
    }

    private _selected;

    get selected() {
        return this._selected;
    }

    set selected(idx) {
        this._selected = idx;
        this._selectTab(idx);
    }

    private _selectTab(idx) {
        this.panelElements.map(el => {
            el.style.display = "none";
            if (this.panelElements.indexOf(el) == idx) {
                el.style.display = "block";                
            }             
        });
    }

    private get titleElements(): Array<HTMLElement> { return Array.from(this.querySelectorAll(".tab-title")) as Array<HTMLElement>; }

    private get panelElements(): Array<HTMLElement> { return Array.from(this.querySelectorAll(".tab-panel")) as Array<HTMLElement>; }

    private get panelsContainer(): HTMLElement { return this.querySelector(".panels") as HTMLElement; }

    private get tabsContainer(): HTMLElement { return this.querySelector(".tabs") as HTMLElement; }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-tabs`,TabsComponent));
