export interface IPagedList<T> {
  IsFirstPage: boolean;
  IsLastPage: boolean;
  PageCount: number;
  TotalCount: number;
  data: T[];
}
