import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MatButtonModule, MatSlideToggleModule } from '@angular/material';

@NgModule({
    imports: [
        CommonModule,
        MatButtonModule,
        MatSlideToggleModule
    ],

    exports: [
        MatButtonModule,
        MatSlideToggleModule
    ],
})

export class AngularMaterialModule {

}