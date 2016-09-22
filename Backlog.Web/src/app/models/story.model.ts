export class Story { 
    public id: number;
    public epicId: number;
    public name: string;
    public isReusable: boolean;
    public priority: number;
    public digitalAssets: Array<any> = [];
    public description: string;
}
