import { Epic, Story, Content } from "../models";

export interface AppState {
    epics: Array<Epic>;
    stories: Array<Story>;
    contents: Array<Content>;
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
