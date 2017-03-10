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

    private async _bind() {        
        const article = await this._articleService.getBySlug(this._slug) as Article;
        this.titleElement.textContent = article.title;
        this.htmlContentElement.innerHTML = article.htmlContent;
    }

    private _slug: string;
    public get titleElement(): HTMLElement { return this.querySelector(".title") as HTMLElement; }
    public get htmlContentElement(): HTMLElement { return this.querySelector(".html-content") as HTMLElement; }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "slug":
                this._slug = newValue;
                break;
        }
    }
}

customElements.define(`ce-article-view`, ArticleViewComponent);