import { TableColumn } from "src/@vex/interfaces/table-column.interface";
import { Category } from "src/app/responses/category/category.response";
import icCategory from "@iconify/icons-ic/twotone-category";
import { ListTableMenu } from "src/app/commons/list-table-menu.interface";

const menuItems: ListTableMenu[] = [{}];

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
  //Table Settings
  tableColumns: tableColumns,
  initialSort: "Id",
  initialSortDir: "desc",
  getInputs: inputs,
  buttonLabel: "EDIT",
  buttonLabel2: "DELETE",
  columnsFilter: tableColumns.map((column) => {
    return {
      label: column.label,
      property: column.property,
      type: column.type,
    };
  }),
};
