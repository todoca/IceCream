import { TableColumn } from "src/@vex/interfaces/table-column.interface";
import { Category } from "src/app/responses/category/category.response";
import icCategory from "@iconify/icons-ic/twotone-category";
import { ListTableMenu } from "src/app/commons/list-table-menu.interface";
import icViewheadline from "@iconify/icons-ic/twotone-view-headline";
import icLabel from "@iconify/icons-ic/twotone-label";
import icCalendarMonth from "@iconify/icons-ic/twotone-calendar-today";
import { GenericValidators } from "@shared/validators/generic-validators";

const searchOptions = [
  {
    label: "Name",
    value: 1,
    placeHolder: "Search by name...",
    validation: [GenericValidators.defaultName],
    validation_desc: "Only letters are allowed in this search",
    min_length: 2,
  },
  {
    label: "Description",
    value: 2,
    placeHolder: "Search by description",
    validation: [GenericValidators.defaultDescription],
    validation_desc: "Only letters and numbers are allowed in this search",
    min_length: 2,
  },
];

const menuItems: ListTableMenu[] = [
  {
    type: "link",
    id: "all",
    icon: icViewheadline,
    label: "All",
  },
  {
    type: "link",
    id: "Active",
    icon: icLabel,
    label: "Active",
    value: 1,
    classes: {
      icon: "text-green",
    },
  },
  {
    type: "link",
    id: "Inactive",
    icon: icLabel,
    label: "Inactive",
    value: 0,
    classes: {
      icon: "text-gray",
    },
  },
];

const tableColumns: TableColumn<Category>[] = [
  {
    label: "Name",
    property: "name",
    type: "text",
    cssClasses: ["font-medium", "w-10"],
  },
  {
    label: "Description",
    property: "description",
    type: "textTruncate",
    cssClasses: ["font-medium", "w-10"],
  },
  {
    label: "Create Date",
    property: "createDate",
    type: "datetime",
    cssClasses: ["font-medium", "w-10"],
  },
  {
    label: "State",
    property: "stateCategory",
    type: "badge",
    cssClasses: ["font-medium", "w-10"],
  },
  {
    label: "",
    property: "menu",
    type: "buttonGroup",
    buttonItems: [
      {
        buttonLabel: "EDIT",
        buttonAction: "edit",
        buttonCondition: null,
        disable: false,
      },
      {
        buttonLabel: "DELETE",
        buttonAction: "delete",
        buttonCondition: null,
        disable: false,
      },
    ],
    cssClasses: ["font-medium", "w-10"],
  },
];

const filters = {
  numFilter: 0,
  textFilter: "",
  stateFilter: null,
  startDate: null,
  endDate: null,
};

const inputs = {
  numFilter: 0,
  textFilter: "",
  stateFilter: null,
  startDate: null,
  endDate: null,
};

export const componentSettings = {
  //Icon
  icCategory: icCategory,
  icCalendarMonth: icCalendarMonth,
  //LAYOUT SETTINGS
  menuOpen: false,
  //Table Settings
  tableColumns: tableColumns,
  initialSort: "Id",
  initialSortDir: "desc",
  getInputs: inputs,
  buttonLabel: "EDIT",
  buttonLabel2: "DELETE",
  //SEARCH FILTERS
  menuItems: menuItems,
  filters: filters,
  dateFilterArray: ["Create Date"],
  searchOptions: searchOptions,
  filters_dates_active: false,
  columnsFilter: tableColumns.map((column) => {
    return {
      label: column.label,
      property: column.property,
      type: column.type,
    };
  }),
};
