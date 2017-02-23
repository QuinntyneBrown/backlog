import { Story } from "../stories";

export class Sprint { 
	public id:number;
    public name: string;
    public stories: Array<Story> = [];
}
