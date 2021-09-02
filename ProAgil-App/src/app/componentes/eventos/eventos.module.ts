import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventosComponent } from './eventos.component';
import { ModalExcluirComponent } from './modal/excluir/excluir.component';
import { ModalNovoComponent } from './modal/novo/novo.component';
import { ModalEditarComponent } from './modal/editar/editar.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { EventoResolve } from 'src/app/resolvers/evento.resolver';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { DetalheComponent } from './detalhe/detalhe.component';

const routes: Routes = [
  {
    path: '',
    component: EventosComponent,
  },
  {
    path: ':modal',
    component: EventosComponent,
    resolve: {
      evento: EventoResolve
    }
  },
  {
    path: ':id/detalhado',
    component: DetalheComponent,
  },
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
    PopoverModule.forRoot(),
  ],
  declarations: [
    EventosComponent,
    EventosComponent,
    DetalheComponent,
    ModalEditarComponent,
    ModalNovoComponent,
    ModalExcluirComponent,
  ],
  providers: []
})
export class EventosModule { }
