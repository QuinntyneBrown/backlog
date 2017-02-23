import { Story } from "../stories";

export class Epic { 
    public id: number;
    public productId: string;
    public name: string;
    public priority: string;
    public stories: Array<Story> = [];
}
