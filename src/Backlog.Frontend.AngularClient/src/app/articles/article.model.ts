import { Author } from "../authors/author.model";
import { Category } from "../categories/category.model";
import { Tag } from "../tags/tag.model";

export class Article {
    public id: number;
    public author: Author;
    public authorId: string;
    public title: string;
    public name: string;
    public slug: string;
    public htmlContent: string;
    public isPublished: boolean;
    public published: string;

    public categories: Array<Category> = [];
    public tags: Array<Tag> = [];
}