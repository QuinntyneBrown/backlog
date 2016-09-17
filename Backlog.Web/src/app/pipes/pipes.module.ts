import { NgModule } from '@angular/core';

import { SortByPriorityPipe } from './sort-by-priority.pipe';

const declarables = [SortByPriorityPipe];

@NgModule({
    exports: [declarables],
    declarations: [declarables]
})
export class PipesModule { }
