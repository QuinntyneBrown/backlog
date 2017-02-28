const template = require("./tabs.component.html");
const styles = require("./tabs.component.scss");

export const tabsEvents = {
    SELECTED_INDEX_CHANGED: "[Tabs] Selected Index Changed"
};

export class SelectedIndexChanged extends CustomEvent {
    constructor(selectedIndex: number) {
        super(tabsEvents.SELECTED_INDEX_CHANGED, {
            cancelable: true,
            bubbles: true,
            detail: { selectedIndex }
        });
    }
}

export class TabsComponent extends HTMLElement {
    constructor() {
        super();
        this.onTitleClick = this.onTitleClick.bind(this);
    }

    static get observedAttributes() {
        return [
            "custom-tab-index"
        ];
    }

    connectedCallback() {
        const titles = this.titleElements;
        const panels = this.panelElements;

        this.innerHTML = `<style>${styles}</style> ${template}`;

        titles.forEach(el => this.tabsContainer.appendChild(el));
        panels.map(el => this.panelsContainer.appendChild(el));

        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this.titleElements.map(el => el.classList.remove("selected"));
        this.selected = this.customTabIndex;
        this.titleElements[this.customTabIndex].classList.add("selected");
    }

    private _addEventListeners() {
        this.titleElements.map(el => el.addEventListener("click", this.onTitleClick));
    }

    disconnectedCallback() {
        this.titleElements.map(el => el.removeEventListener("click", this.onTitleClick));
    }

    onTitleClick(e: any) {
        this.titleElements.map(el => el.classList.remove("selected"));
        e.currentTarget.classList.add("selected");
        this._selectTab(this.titleElements.indexOf(e.currentTarget));
        var index = this.titleElements.indexOf(e.currentTarget);
        this.dispatchEvent(new SelectedIndexChanged(this.titleElements.indexOf(e.currentTarget)));
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

    private customTabIndex = 0;

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "custom-tab-index":
                this.customTabIndex = JSON.parse(newValue);

                if (this.parentNode)
                    this._bind();

                break;
        }
    }

    private get titleElements(): Array<HTMLElement> { return Array.from(this.querySelectorAll(".tab-title")) as Array<HTMLElement>; }

    private get panelElements(): Array<HTMLElement> { return Array.from(this.querySelectorAll(".tab-panel")) as Array<HTMLElement>; }

    private get panelsContainer(): HTMLElement { return this.querySelector(".panels") as HTMLElement; }

    private get tabsContainer(): HTMLElement { return this.querySelector(".tabs") as HTMLElement; }
}

customElements.define(`ce-tabs`, TabsComponent);
