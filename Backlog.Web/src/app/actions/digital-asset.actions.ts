import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { DigitalAssetService } from "../services";
import { AppState, AppStore } from "../store";
import {
    DIGITAL_ASSET_ADD_SUCCESS,
    DIGITAL_ASSET_GET_SUCCESS,
    DIGITAL_ASSET_REMOVE_SUCCESS,
    DIGITAL_ASSET_UPLOAD_SUCCESS
} from "../constants";

import { DigitalAsset } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class DigitalAssetActions {
    constructor(private _digitalAssetService: DigitalAssetService, private _store: AppStore) { }

    public add(digitalAsset: DigitalAsset) {
        const newGuid = guid();
        this._digitalAssetService.add(digitalAsset)
            .subscribe(digitalAsset => {
                this._store.dispatch({
                    type: DIGITAL_ASSET_ADD_SUCCESS,
                    payload: digitalAsset
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._digitalAssetService.get()
            .subscribe(digitalAssets => {
                this._store.dispatch({
                    type: DIGITAL_ASSET_GET_SUCCESS,
                    payload: digitalAssets
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._digitalAssetService.remove({ id: options.id })
            .subscribe(digitalAsset => {
                this._store.dispatch({
                    type: DIGITAL_ASSET_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._digitalAssetService.getById({ id: options.id })
            .subscribe(digitalAsset => {
                this._store.dispatch({
                    type: DIGITAL_ASSET_GET_SUCCESS,
                    payload: [digitalAsset]
                });
                return true;
            });
    }

    public upload(options: { formData: FormData, id: number }) {
        return this._digitalAssetService.upload({ formData: options.formData, id: options.id })
            .subscribe(result => {
                this._store.dispatch({
                    type: DIGITAL_ASSET_UPLOAD_SUCCESS,
                    payload: { id: options.id, result: result }
                });
                return true;
            });
    }
}
