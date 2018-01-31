import { BrandOwner } from "./brand-owner.model";
import { Feature } from "../features/feature.model";
import { TemplateModel } from "../templates/template.model";

export class Brand { 
    public id: number;
    public templateId: any;
    public name: string;
    public template: TemplateModel;
    public brandOwners: Array<BrandOwner> = [];
    public features: Array<Feature> = [];
}
