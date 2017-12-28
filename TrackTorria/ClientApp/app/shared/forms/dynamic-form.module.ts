import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
    ReactiveFormsModule
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
