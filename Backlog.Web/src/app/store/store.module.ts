import { NgModule } from '@angular/core';
import * as ngrxStore from '@ngrx/store';
import { compose } from "@ngrx/core/compose";
import { localStorageSync } from "ngrx-store-localstorage";

import { AppStore } from "./app-store";
import { initialState } from "./initial-state";

import { epicsReducer } from "./epic.reducer";
import { storiesReducer } from "./story.reducer";

const providers = [
    AppStore
];

@NgModule({
    imports: [
        ngrxStore.StoreModule.provideStore(
            {
                epics: epicsReducer,
                stories: storiesReducer
            },
            [initialState]
        )],
    providers: providers
})
export class StoreModule { }
