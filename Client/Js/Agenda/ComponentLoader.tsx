import * as React from "react";
import { createRoot } from "react-dom/client";

import Agenda from "./Components/Agenda";

export class ComponentLoader {
  public static load(): void {
    document.querySelectorAll(".Agenda").forEach((el) => {
      createRoot(el).render(
        <Agenda
        />
      );
    });
  }
}
