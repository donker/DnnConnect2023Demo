import DataService from "../Service";

export interface IAppModule {
  moduleId: number;
  tabId: number;
  locale: string;
  resources: any;
  common: any;
  service: DataService;
}

export class AppModule implements IAppModule {
  public moduleId: number;
  public tabId: number;
  public locale: string;
  public resources: any;
  public common: any;
  public service: DataService;
  constructor(moduleId: number, tabId: number, locale: string, resources: any, common: any, service: DataService) {
    this.moduleId = moduleId;
    this.tabId = tabId;
    this.locale = locale;
    this.resources = resources;
    this.common = common;
    this.service = service;
  }
}
