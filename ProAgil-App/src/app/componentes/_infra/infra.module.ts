import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastComponent } from './toast/toast.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
  ],
  exports: [ToastComponent],
  declarations: [ToastComponent]
})
export class InfraModule { }
