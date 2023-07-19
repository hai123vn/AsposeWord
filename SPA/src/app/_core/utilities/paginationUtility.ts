export interface PaginationUtility<T> {
    pagination: PaginationResult;
    result: T[];
}

export interface PaginationResult {
    totalCount: number;
    totalPage: number;
    pageNumber: number;
    pageSize: number;
    skip: number;
}

export interface PaginationParam {
    pageNumber: number;
    pageSize: number;
}