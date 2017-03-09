import { Epic } from "../epics";

export class Product { 
	public id:string;
    public name: string;
    public epics: Array<Epic> = [];
}
