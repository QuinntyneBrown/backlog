import { Article } from "./article.model";
import { ArticleService } from "./article.service";
import { EditorComponent } from "../shared";
import { ArticleAddSuccess, ArticleDeleteSuccess } from "./actions";

const template = require("./article-edit.component.html");
const styles = require("./article-edit.component.scss");

export class ArticleEditComponent extends HTMLElement {
    constructor(private _articleService: ArticleService = ArticleService.Instance) {
        super();

    }

    static get observedAttributes() {
        return ["article-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this._bind();
        this._addEventListeners();
    }

    private _bind() {
        this.titleElement.textContent = "Create Spec";
        this.htmlContentEditor = new EditorComponent(this.htmlContentElement);
        if (this.articleId) {
            this._articleService.getById(this.articleId).then((results: string) => {
                var resultsJSON: Article = JSON.parse(results) as Article;
                this.articleTitleInputElement.value = resultsJSON.title;
            });
            this.titleElement.textContent = "Edit Spec";
        } else {
            this.deleteButtonElement.style.display = "none";
        } 
    }

    private _addEventListeners() {
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));
    }

    public onSave() {
        var article = {
            id: this.articleId,
            title: this.articleTitleInputElement.value,
            htmlContent: this.htmlContentEditor.text
        } as Article;
        
        this._articleService.add(article).then((results) => {
            this.dispatchEvent(new ArticleAddSuccess(article));
        });
    }

    public onDelete() {        
        this._articleService.remove({ id: this.articleId }).then((results) => {
            this.dispatchEvent(new ArticleDeleteSuccess(this.articleId));
        });
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "article-id":
                this.articleId = newValue;
				break;
        }        
    }

    public articleId: number;
    public htmlContentEditor: EditorComponent;
    public get titleElement(): HTMLElement { return this.querySelector("h2") as HTMLInputElement; }
    public get htmlContentElement(): HTMLElement { return this.querySelector(".article-html-content") as HTMLElement; }
    public get saveButtonElement(): HTMLButtonElement { return this.querySelector(".save-button") as HTMLButtonElement; };
    public get deleteButtonElement(): HTMLButtonElement { return this.querySelector(".delete-button") as HTMLButtonElement; };
    public get articleTitleInputElement(): HTMLInputElement { return this.querySelector(".article-title") as HTMLInputElement; }
}

document.addEventListener("DOMContentLoaded",() => window.customElements.define(`ce-article-edit`,ArticleEditComponent));
