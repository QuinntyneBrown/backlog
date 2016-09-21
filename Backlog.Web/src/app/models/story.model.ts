export class Story { 
    public id: number;
    public epicId: number;
    public name: string;
    public isTemplate: boolean;
    public priority: number;
    public digitalAssets: Array<any> = [];
    public description: string;
}
