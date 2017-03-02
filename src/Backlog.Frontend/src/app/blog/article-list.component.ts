import { Article } from "./article.model";
import { ArticleService } from "./article.service";
import { createElement } from "../utilities";

const template = require("./article-list.component.html");
const styles = require("./article-list.component.scss");

export class ArticleListComponent extends HTMLElement {
    constructor(private _articleService: ArticleService = ArticleService.Instance) {
        super();
    }

    async connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        const results = await this._articleService.get() as string;
        const resultsJSON: Array<Article> = (JSON.parse(results) as { articles: Array<Article> }).articles;
        for (var i = 0; i < resultsJSON.length; i++) {
            this.appendChild(createElement(`<ce-article-item entity='${JSON.stringify(resultsJSON[i])}'></ce-article-item>`));
        }
    }
}

customElements.define("ce-article-list", ArticleListComponent);