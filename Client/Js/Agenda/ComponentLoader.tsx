import * as React from "react";
import { createRoot } from "react-dom/client";

import Agenda from "./Components/Agenda";
import { AppModule } from "./Models/IAppModule";
import DataService from "./Service";

declare global {
  interface Element {
    dataInt: (prop: string) => number;
    dataString: (prop: string, defaultValue: string) => string;
    dataObject: (prop: string) => any;
  }
}

Element.prototype.dataInt = function (this: Element, prop: string): number {
  if (this.getAttribute("data-" + prop) == null) return 0;
  return parseInt(this.getAttribute("data-" + prop) as string);
};
Element.prototype.dataString = function (
  this: Element,
  prop: string,
  defaultValue: string
): string {
  if (this.getAttribute("data-" + prop) == null) return defaultValue;
  return this.getAttribute("data-" + prop) as string;
};
Element.prototype.dataObject = function (this: Element, prop: string): any {
  if (this.getAttribute("data-" + prop) == null) return null;
  return JSON.parse(this.getAttribute("data-" + prop) as string);
};

export class ComponentLoader {
  public static load(): void {
    document.querySelectorAll(".Agenda").forEach((el) => {
      const moduleId = el.dataInt("moduleid");
      var x = new AppModule(
        moduleId,
        el.dataInt("tabid"),
        el.dataString("locale", "en-US"),
        el.dataObject("resources"),
        new DataService(moduleId)
      )
      createRoot(el).render(
        <Agenda
          module={x}
          detailUrl={el.dataString("detailurl", "")}
          cities={el.dataObject("cities")}
          categories={el.dataObject("categories")}
          venues={el.dataObject("venues")}
        />
      );
    });
  }
}
