import DataService from "../Service";

export interface IAppModule {
  moduleId: number;
  tabId: number;
  locale: string;
  service: DataService;
}

export class AppModule implements IAppModule {
  public moduleId: number;
  public tabId: number;
  public locale: string;
  public service: DataService;
  constructor(moduleId: number, tabId: number, locale: string, service: DataService) {
    this.moduleId = moduleId;
    this.tabId = tabId;
    this.locale = locale;
    this.service = service;
  }
}
