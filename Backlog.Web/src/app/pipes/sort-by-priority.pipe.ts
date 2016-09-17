import { Pipe, PipeTransform } from '@angular/core';


@Pipe({ name: 'sortByPriority' })
export class SortByPriorityPipe implements PipeTransform {
    transform(value: Array<any>, args?: any[]) {
        if (!value || !value.sort) { return value; }        
        return value.sort((a: any, b: any) => {
            if (a.priority < b.priority) { return 1; }
            return 0;
        });
    }
}