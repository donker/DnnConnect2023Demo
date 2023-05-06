import * as React from "react";
import { createRoot } from "react-dom/client";

import { AppManager } from "./AppManager";
import Agenda from "./Components/Agenda";

export class ComponentLoader {
  public static load(): void {
    document.querySelectorAll(".Agenda").forEach((el) => {
      var moduleId = el.dataInt("moduleid");
      createRoot(el).render(
        <Agenda
          module={AppManager.Modules.Item(moduleId.toString())}
          cities={el.dataObject("cities")}
          categories={el.dataObject("categories")}
          venues={el.dataObject("venues")}
          detailUrl={el.dataString("detailurl", "")}
          canEdit={el.dataBoolean("canedit")}
        />
      );
    });
  }
}
