import * as React from "react";
import { createRoot } from "react-dom/client";

import Agenda from "./Components/Agenda";

declare global {
  interface Element {
    dataInt: (prop: string) => number;
  }
}

Element.prototype.dataInt = function (this: Element, prop: string): number {
  if (this.getAttribute("data-" + prop) == null) return 0;
  return parseInt(this.getAttribute("data-" + prop) as string);
};

export class ComponentLoader {
  public static load(): void {
    document.querySelectorAll(".Agenda").forEach((el) => {
      createRoot(el).render(
        <Agenda
          moduleId={el.dataInt("moduleid")}
        />
      );
    });
  }
}
