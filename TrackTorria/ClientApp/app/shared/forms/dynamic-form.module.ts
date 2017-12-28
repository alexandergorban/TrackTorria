import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  MatAutocompleteModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatIconModule,
  MatInputModule,
  MatRadioModule,
  MatSelectModule,
  MatSliderModule,
  MatSlideToggleModule
  } from "@angular/material";

// Components
import { DynamicFormComponent } from './dynamic-form/dynamic-form.component';
import { DynamicFormControlComponent } from './dynamic-form-control/dynamic-form-control.component';
import { ErrorSummaryComponent } from './error-summary/error-summary.component';

// Services
import { FormControlService } from './form-control.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    MatAutocompleteModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatIconModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule
  ],
  declarations: [
    DynamicFormComponent,
    DynamicFormControlComponent,
    ErrorSummaryComponent
  ],
  exports: [
    DynamicFormComponent,
    DynamicFormControlComponent,
    ErrorSummaryComponent
  ],
  providers: [
    FormControlService
  ]
})
export class DynamicFormModule {

}
