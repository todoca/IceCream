export interface Category {
  categoryId: number;
  name: string;
  description: string;
  createDate: Date;
  state: number;
  stateCategory: string;
}

export interface CategoryApi {
  data: any;
  totalRecords: number;
}
