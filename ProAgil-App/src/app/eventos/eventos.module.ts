import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventosComponent } from './eventos.component';
import { ModalExcluirComponent } from './modal/excluir/excluir.component';
import { ModalNovoComponent } from './modal/novo/novo.component';
import { ModalEditarComponent } from './modal/editar/editar.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: EventosComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild(routes), 
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),

  ],
  declarations: [
    EventosComponent,
    EventosComponent,
    ModalEditarComponent,
    ModalNovoComponent,
    ModalExcluirComponent,
  ]
})
export class EventosModule { }
