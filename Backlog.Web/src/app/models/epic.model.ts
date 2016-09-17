import { Story } from "./story.model";

export class Epic { 
    public id: number;
    public priority: number;
    public name: string;
    public description: string;
    public stories: Array<Story> = [];
}
