import { IPagedList } from "./ipaged-list.d";
import { validatePagePropertiesAndGetSkipCount } from "./validate-page-properties-and-get-skip-count";
import { PagingConfig } from "./paging-config.model";
import { PagedList } from "./paged-list.model";

export function toPageListFromInMemory<T>(entities: Array<T>, page: number, pageSize: number): IPagedList<T> {
    if (entities == null)
        throw new Error("entities");
    var pagingConfig = new PagingConfig(page, pageSize);
    var skipCount = validatePagePropertiesAndGetSkipCount(pagingConfig);
    var data = entities.slice(skipCount, pageSize + skipCount);
    return new PagedList(data, page, pageSize, entities.length);    
}

