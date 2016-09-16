import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

const declarables = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables]
})
export class PipesModule { }
