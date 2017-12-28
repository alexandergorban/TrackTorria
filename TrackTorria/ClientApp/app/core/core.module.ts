import { NgModule, Optional, SkipSelf, ModuleWithProviders, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
//import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { OAuthModule } from 'angular-oauth2-oidc';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
//    HttpClientModule,
    RouterModule,
    OAuthModule.forRoot(),
  ],
  exports: [
    RouterModule,

  ],
  providers: []
})
export class CoreModule {

}
