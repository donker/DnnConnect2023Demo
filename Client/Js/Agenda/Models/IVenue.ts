export interface IVenue {
  VenueId: number;
  ModuleId: number;
  VenueName: string;
  City: string;
}

export class Venue implements IVenue {
  VenueId: number;
  ModuleId: number;
  VenueName: string;
  City: string;
    constructor() {
  this.VenueId = -1;
  this.ModuleId = -1;
  this.VenueName = "";
  this.City = "";
   }
}

