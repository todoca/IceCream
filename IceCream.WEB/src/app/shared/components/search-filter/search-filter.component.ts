import { Component, Inject, Output, OnInit, EventEmitter } from "@angular/core";
import { MAT_DIALOG_DATA } from "@angular/material/dialog";
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from "@angular/forms";
import icClose from "@iconify/icons-ic/twotone-close";
import { DateAdapter } from "@angular/material/core";

@Component({
  selector: "vex-search-filter",
  templateUrl: "./search-filter.component.html",
  styleUrls: ["./search-filter.component.scss"],
})
export class SearchFilterComponent implements OnInit {
  icClose = icClose;
  dateOne: UntypedFormGroup;
  dateTwo: UntypedFormGroup;
  isActive = false;

  labelDateOne = "Date Filter One";
  labelDateTwo = "Date Filter Two";

  showDateTwo = false;

  @Output() datesFilter = new EventEmitter<any>();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private fb: UntypedFormBuilder,
    private dateAdapter: DateAdapter<Date>
  ) {
    this.initForm();
  }

  ngOnInit(): void {
    this.dateAdapter.setLocale("en-US");
  }

  initForm() {
    this.showDateTwo = !(this.data[1].labelDate === undefined);

    switch (this.data.length) {
      case 1:
        this.initFormOneDate();
        break;
      case 2:
        this.initFormTwoDates();
        break;
    }
  }

  initFormOneDate() {
    this.labelDateOne = this.data[0].labelDate;

    this.dateOne = this.fb.group({
      startDate: [this.data[0].startDate, [Validators.required]],
      endDate: [this.data[0].endDate, [Validators.required]],
    });
    this.dateTwo = this.fb.group({
      startDateTwo: [this.data[1].startDate, [Validators.required]],
      endDateTwo: [this.data[1].endDate, [Validators.required]],
    });
  }

  initFormTwoDates() {
    this.labelDateOne = this.data[0].labelDate;
    this.labelDateTwo = this.data[1].labelDate;

    this.dateOne = this.fb.group({
      startDate: [this.data[0].startDate, [Validators.required]],
      endDate: [this.data[0].endDate, [Validators.required]],
    });
    this.dateTwo = this.fb.group({
      startDateTwo: [this.data[1].startDate, [Validators.required]],
      endDateTwo: [this.data[1].endDate, [Validators.required]],
    });
  }

  submit() {
    if (this.dateOne.valid || this.dateTwo.valid) {
      let data = {
        startDate: this.dateOne.value.startDate,
        endDate: this.dateOne.value.endDate,
        startDateTwo: this.dateTwo.value.startDateTwo,
        endDateTwo: this.dateTwo.value.endDateTwo,
      };

      this.datesFilter.emit(data);
    }
  }

  clear() {
    this.dateOne.reset();
    this.dateTwo.reset();

    let data = {
      startDate: this.dateOne.value.startDate,
      endDate: this.dateOne.value.endDate,
      startDateTwo: this.dateTwo.value.startDateTwo,
      endDateTwo: this.dateTwo.value.endDateTwo,
    };
    this.datesFilter.emit(data);
  }
}
