export interface IItem {
  ItemId: number;
  ModuleId: number;
  DateFrom: string;
  DateTo: string;
  Title: string;
  Description: string;
  Venue: number;
  Category: number;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  VenueName: string;
  City: string;
  CategoryName: string;
  CreatedByUser: string;
  ModifiedByUser: string;
}

export class Item implements IItem {
  ItemId: number;
  ModuleId: number;
  DateFrom: string;
  DateTo: string;
  Title: string;
  Description: string;
  Venue: number;
  Category: number;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  VenueName: string;
  City: string;
  CategoryName: string;
  CreatedByUser: string;
  ModifiedByUser: string;
  constructor() {
    this.ItemId = -1;
    this.ModuleId = -1;
    this.Title = "";
    this.Venue = -1;
    this.Category = -1;
    this.DateFrom = "";
    this.DateTo = "";
    this.CreatedByUserID = -1;
    this.CreatedOnDate = new Date();
    this.LastModifiedByUserID = -1;
    this.LastModifiedOnDate = new Date();
    this.VenueName = "";
    this.City = "";
    this.CategoryName = "";
  }
}
