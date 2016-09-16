import { Epic, Story, Content, Tag, Sprint, AgileTeam } from "../models";

export interface AppState {
    epics: Array<Epic>;
    stories: Array<Story>;
    contents: Array<Content>;
    tags: Array<Tag>,
    sprints: Array<Sprint>,
    agileTeams: Array<AgileTeam>,
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
