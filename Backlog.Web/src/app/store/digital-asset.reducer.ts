import { Action } from "@ngrx/store";
import { DIGITAL_ASSET_ADD_SUCCESS, DIGITAL_ASSET_GET_SUCCESS, DIGITAL_ASSET_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { DigitalAsset } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const digitalAssetsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case DIGITAL_ASSET_ADD_SUCCESS:
            var entities: Array<DigitalAsset> = state.digitalAssets;
            var entity: DigitalAsset = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { digitalAssets: entities });

        case DIGITAL_ASSET_GET_SUCCESS:
            var entities: Array<DigitalAsset> = state.digitalAssets;
            var newOrExistingDigitalAssets: Array<DigitalAsset> = action.payload;
            for (let i = 0; i < newOrExistingDigitalAssets.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingDigitalAssets[i] });
            }                                    
            return Object.assign({}, state, { digitalAssets: entities });

        case DIGITAL_ASSET_REMOVE_SUCCESS:
            var entities: Array<DigitalAsset> = state.digitalAssets;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { digitalAssets: entities });

        default:
            return state;
    }
}

