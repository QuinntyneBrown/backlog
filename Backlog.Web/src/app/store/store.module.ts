import { NgModule } from '@angular/core';
import * as ngrxStore from '@ngrx/store';
import { compose } from "@ngrx/core/compose";
import { localStorageSync } from "ngrx-store-localstorage";

import { AppStore } from "./app-store";
import { initialState } from "./initial-state";

import { epicsReducer } from "./epic.reducer";
import { contentsReducer } from "./content.reducer";
import { storiesReducer } from "./story.reducer";
import { sprintsReducer } from "./sprint.reducer";
import { tagsReducer } from "./tag.reducer";
import { agileTeamsReducer } from "./agile-team.reducer";

const providers = [
    AppStore
];

@NgModule({
    imports: [
        ngrxStore.StoreModule.provideStore(
            {
                contents: contentsReducer,
                epics: epicsReducer,
                stories: storiesReducer,
                sprints: sprintsReducer,
                tag: tagsReducer,
                agileTeams: agileTeamsReducer
            },
            [initialState]
        )],
    providers: providers
})
export class StoreModule { }
