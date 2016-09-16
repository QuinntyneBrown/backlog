import { Epic, Story, Content, Tag, Sprint, AgileTeam, Theme } from "../models";

export interface AppState {
    epics: Array<Epic>;
    stories: Array<Story>;
    contents: Array<Content>;
    tags: Array<Tag>,
    sprints: Array<Sprint>,
    agileTeams: Array<AgileTeam>,
    themes: Array<Theme>,
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
