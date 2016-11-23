import { Article } from "./article.model";
import { ArticleService } from "./article.service";
import { createElement } from "../utilities";
let template = require("./article-list.component.html");
let styles = require("./article-list.component.scss");

export class ArticleListComponent extends HTMLElement {
    constructor(private _articleService: ArticleService = ArticleService.Instance) {
        super();
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._articleService.get().then((results: string) => {
            var resultsJSON: Array<Article> = JSON.parse(results) as Array<Article>;
            for (var i = 0; i < resultsJSON.length; i++) {
                this.appendChild(createElement(`<ce-article-item entity='${JSON.stringify(resultsJSON[i])}'></ce-article-item>`));
            }
        });
    }
}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-article-list", ArticleListComponent));
