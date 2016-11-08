import { Story } from "../stories";

export class Epic { 
	public id:number;
    public name: string;
    public priority: string;
    public stories: Array<Story> = [];
}
