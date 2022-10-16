import { SearchFilterComponent } from "@shared/components/search-filter/search-filter.component";

export function DatesFilter(component: any) {
  let dateFilterArray = [
    {
      labelDate: component.component.dateFilterArray[0],
      startDate: component.component.filters.startDate,
      endDate: component.component.filters.endDate,
    },
    {},
  ];

  let dialogDatesFilter = component._dialog.open(SearchFilterComponent, {
    width: "380px",
    data: dateFilterArray,
  });

  dialogDatesFilter.componentInstance.datesFilter.subscribe((data) => {
    component.component.filters.startDate = data.startDate;
    component.component.filters.endDate = data.endDate;

    let filter_active = false;

    Object.entries(data).forEach(([key, value]) => {
      if (value != null && filter_active == false) {
        filter_active = true;
      }
    });
    component.component.filters_dates_active = filter_active;
    dialogDatesFilter.close(true);
  });

  dialogDatesFilter.afterClosed().subscribe((data: any) => {
    if (data) {
      component.formatGetInputs();
    }
  });
}
