import { Epic, Story } from "../models";

export interface AppState {
    epics: Array<Epic>;
    stories: Array<Story>;
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
