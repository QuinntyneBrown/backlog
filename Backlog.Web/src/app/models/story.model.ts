export class Story { 
    public id: number;
    public epicId: number;
    public name: string;
    public isReusable: boolean;
    public priority: number;
    public acceptanceCriteria: string;
    public notes: string;
    public digitalAssets: Array<any> = [];
    public description: string;
}
