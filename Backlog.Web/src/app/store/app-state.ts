import { Epic, Story, Content, Tag, Sprint, AgileTeam, Theme, DigitalAsset, HtmlContent, ReusableStoryGroup, Project } from "../models";

export interface AppState {
    epics: Array<Epic>;
    stories: Array<Story>;
    contents: Array<Content>;
    tags: Array<Tag>,
    sprints: Array<Sprint>,
    agileTeams: Array<AgileTeam>,
    themes: Array<Theme>,
    digitalAssets: Array<DigitalAsset>,
    htmlContents: Array<HtmlContent>, 
    reusableStoryGroups: Array<ReusableStoryGroup>,
    projects: Array<Project>,
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
