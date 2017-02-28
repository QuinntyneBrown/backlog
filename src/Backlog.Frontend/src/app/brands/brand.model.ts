import { BrandOwner } from "./brand-owner.model";
import { Feature } from "../features";
import { TemplateModel } from "../templates";

export class Brand { 
    public id: number;
    public templateId: any;
    public name: string;
    public template: TemplateModel;
    public brandOwners: Array<BrandOwner> = [];
    public features: Array<Feature> = [];
}
