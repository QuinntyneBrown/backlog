import { Tag } from "./tag.model";
import { Author } from "./author.model";

export class Article { 
    public id: number;
    public author: Author;
    public authorId: string;
    public title: string;
    public slug: string;
    public htmlContent: string;
    public isPublished: boolean;
    public published: string;
    public tags: Array<Tag> = [];
}