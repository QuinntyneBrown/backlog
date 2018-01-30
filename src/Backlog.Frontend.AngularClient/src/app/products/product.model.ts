import { Epic } from "../epics/epic.model";

export class Product { 
	public id:string;
    public name: string;
    public epics: Array<Epic> = [];
}
