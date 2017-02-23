export interface IPagedList<T> {
    data: Array<T>;
    page: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
}