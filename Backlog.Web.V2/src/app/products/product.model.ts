import { Epic } from "../epics";

export class Product { 
	public id:number;
    public name: string;
    public epics: Array<Epic> = [];
}
