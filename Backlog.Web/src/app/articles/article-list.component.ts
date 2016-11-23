import { Article } from "./article.model";
import { ArticleService } from "./article.service";
import { createElement } from "../utilities";
import { articleActions, ArticleEditSelect } from "./actions";
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
                this.children[this.children.length - 1].addEventListener(articleActions.SELECT, this.onArticleListelect.bind(this));
                this.children[this.children.length - 1].addEventListener(articleActions.DELETE, this.onArticleDeleteSelect.bind(this));
            }
        });
    }

    public onArticleListelect(event: ArticleEditSelect) {
        this.dispatchEvent(new ArticleEditSelect(event.detail.articleId));
    }

    public onArticleDeleteSelect(event: ArticleEditSelect) {
        this._articleService.remove({ id: event.detail.articleId }).then((results) => {
            event.target.removeEventListener(articleActions.SELECT, this.onArticleListelect.bind(this));
            event.target.removeEventListener(articleActions.DELETE, this.onArticleDeleteSelect.bind(this));
            this.removeChild(event.target as any);
        });
    }

}

document.addEventListener("DOMContentLoaded", () => window.customElements.define("ce-article-list", ArticleListComponent));
