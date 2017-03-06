import { ArticleService } from "./article.service";
import { Article } from "./article.model";

const template = require("./article-view.component.html");
const styles = require("./article-view.component.scss");

export class ArticleViewComponent extends HTMLElement {
    constructor(private _articleService: ArticleService = ArticleService.Instance) {
        super();
    }

    static get observedAttributes () {
        return [
            "slug"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private _bind() {        
        this._articleService.getBySlug(this._slug).then((results:string) => {
            const resultsJSON = JSON.parse(results) as Article;
            this.titleElement.textContent = resultsJSON.title;
            this.htmlContentElement.innerHTML = resultsJSON.htmlContent;
        });
    }

    private _slug: string;
    public get titleElement(): HTMLElement { return this.querySelector(".title") as HTMLElement; }
    public get htmlContentElement(): HTMLElement { return this.querySelector(".html-content") as HTMLElement;}

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "slug":
                this._slug = newValue;
                break;
        }
    }
}

customElements.define(`ce-article-view`, ArticleViewComponent);