import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { App } from './app';
import { SharedModule } from './shared/shared.module';
import { ComponentsModule } from '@components/components.module';

@NgModule({
  declarations: [App],
  bootstrap: [App],
  imports: [BrowserModule, SharedModule, ComponentsModule],
})
export class AppModule {}
