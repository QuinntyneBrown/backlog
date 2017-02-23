import { PagingConfig  } from "./paging-config.model";

export function validatePagePropertiesAndGetSkipCount(pagingConfig: PagingConfig) {

    if (pagingConfig.page < 1) {
        pagingConfig.page = 1;
    }

    if (pagingConfig.pageSize < 1) {
        pagingConfig.pageSize = 1;
    }

    if (pagingConfig.pageSize > 100) {
        pagingConfig.pageSize = 100;
    }

    return pagingConfig.pageSize * (pagingConfig.page - 1);
}