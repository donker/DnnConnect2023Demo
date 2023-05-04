export interface ICategory {
  CategoryId: number;
  ModuleId: number;
  CategoryName: string;
}

export class Category implements ICategory {
  CategoryId: number;
  ModuleId: number;
  CategoryName: string;
    constructor() {
  this.CategoryId = -1;
  this.ModuleId = -1;
  this.CategoryName = "";
   }
}

