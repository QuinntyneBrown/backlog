import { Article } from "./article.model";
import { ArticleService } from "./article.service";
import { EditorComponent } from "../shared";
import { Router } from "../router";

const template = require("./article-edit.component.html");
const styles = require("./article-edit.component.scss");

export class ArticleEditComponent extends HTMLElement {
    constructor(
        private _articleService: ArticleService = ArticleService.Instance,
        private _router: Router = Router.Instance
    ) {
        super();
    }

    static get observedAttributes() {
        return ["article-id"];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {
        this.titleElement.textContent = "Create Article";
        this.htmlContentEditor = new EditorComponent(this.htmlContentElement);

        if (this.articleId) {            
            const article: Article = await this._articleService.getById(this.articleId);
            this.articleTitleInputElement.value = article.title;
            this.htmlContentEditor.setHTML(article.htmlContent); 
            this.titleElement.textContent = "Edit Article";
        } else {
            this.deleteButtonElement.style.display = "none";
        } 
    }

    private _setEventListeners() {
        this.saveButtonElement.addEventListener("click", this.onSave.bind(this));
        this.deleteButtonElement.addEventListener("click", this.onDelete.bind(this));
    }

    public async onSave() {
        const article = {
            id: this.articleId,
            title: this.articleTitleInputElement.value,
            htmlContent: this.htmlContentEditor.text
        } as Article;
        
        await this._articleService.add(article);
        this._router.navigate(["article", "list"]);

    }

    public async onDelete() {
        await this._articleService.remove({ id: this.articleId });
        this._router.navigate(["article", "list"]);
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

customElements.define(`ce-article-edit`,ArticleEditComponent);
