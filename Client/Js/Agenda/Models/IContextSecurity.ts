export interface IContextSecurity {
  UserId: number;
  CanView: boolean;
  CanEdit: boolean;
  CanManage: boolean;
  IsAdmin: boolean;
}
