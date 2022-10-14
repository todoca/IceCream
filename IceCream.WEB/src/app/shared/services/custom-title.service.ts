import { Injectable } from "@angular/core";
import { Title } from "@angular/platform-browser";
import { environment } from "./../../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class CustomTitleService {
  prefix = environment.production ? "" : "DEV:: ";

  constructor(private titleService: Title) {}

  set(title) {
    this.titleService.setTitle(
      this.prefix + title + " - TODOCA® Ice Cream App"
    );
  }
}
