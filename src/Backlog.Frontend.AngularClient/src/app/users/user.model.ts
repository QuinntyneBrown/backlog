import { Profile } from "./profile.model";

export type User = { 
    id:any;   
    name: string;
    description: string;
    imageUrl: string;
    profile: Partial<Profile>;
}
