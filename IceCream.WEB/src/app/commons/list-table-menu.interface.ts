import { Icon } from "@visurel/iconify-angular";

export interface ListTableMenu {
  type: "link" | "subheading" | "button";
  id?: "all" | "Active" | "Inactive";
  icon?: Icon;
  label: string;
  value?: number;
  classes?: {
    icon?: string;
  };
  size?: string;
}
