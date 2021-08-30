import { Component, OnInit, TemplateRef } from '@angular/core';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastService } from '../componentes/infra/toast/toast.service';
import { Evento } from '../models/Evento';
import { Lote } from '../models/Lote';
import { EventoService } from '../services/evento.service';
import { ModalEditarComponent } from './modal/editar/editar.component';
import { ModalExcluirComponent } from './modal/excluir/excluir.component';
import { ModalNovoComponent } from './modal/novo/novo.component';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: Evento[] = [];
  imagemAltura = 50;
  imagemMargem = 2;
  mostrarImagem = true;
  _filtroLista: string = '';

  get filtroLista(): string {
    return this._filtroLista;
  }
  
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(value) : this.eventos;
  }

  eventosFiltrados: Evento[] = [];

  constructor(
    private service: EventoService,
    private modal: BsModalService,
    private toastService: ToastService
  ) {
  }

  ngOnInit(): void {
    this.carregdaDados();
  }

  onChangeFilter(value: any) {
    alert(JSON.stringify(value));
  }

  filtrarEventos(filtrarPor: string): any[] {
    let contains: Function = (value: string) => value.toLocaleLowerCase()
      .indexOf(filtrarPor.toLocaleLowerCase()) !== -1;
    return this.eventos.filter(
      (e: Evento) => contains(e.tema) || contains(e.local)
    );
  }

  carregdaDados(): void {
    this.service.get()
      .subscribe(
        (_eventos: Evento[]) => {
          this.eventos = _eventos;
          this.eventosFiltrados = _eventos;
        },
        err => {
          console.log(err);
        }
      );
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  salvarAlteracoes(): void {

  }

  openModalEditar(evento: Evento): void {
    const initialState = {
      evento: evento
    }
    this.modal.show(ModalEditarComponent, { initialState })
      .content?.onClose.subscribe(
        (res: any) => {
          if (res) {
            console.log(Object.assign(evento, res));
            this.service.update(Object.assign(evento, res))
              .subscribe(
                (res) => {
                  this.carregdaDados();
                  this.toastService.show('Sucesso', `O evento ${evento.tema}, foi alterado!`)
                },
                err => {
                  this.toastService.show('ERRO', JSON.stringify(err))
                }
              )
          }
        }
      );
  }

  openModalNovo() {
    this.modal.show(ModalNovoComponent, { class: 'modal-lg', ignoreBackdropClick: true })
      .content?.onClose.subscribe(
        (res: any) => {
          if (res) {
            const newEvento: Evento = Object.assign(res);
            this.service.create(newEvento)
              .subscribe(
                (novoEvento: Evento) => {
                  console.log(novoEvento);
                  this.carregdaDados();
                  this.toastService.show('Sucesso', 'Novo Evento foi inserido na agenda!')
                },
                err => {
                  console.error(err);
                }
              );
          }
        }
      );
  }

  openModalExcluir(evento: Evento) {
    const initialState = {
      body: `Dejesa realmente excluir o evento ${evento.tema}, codigo ${evento.id}`
    }
    this.modal.show(ModalExcluirComponent, { initialState, ignoreBackdropClick: true })
      .content?.onClose.subscribe(
        (res: any) => {
          if (res) {
            this.service.delete(evento.id)
              .subscribe(
                (novoEvento: Evento) => {
                  this.carregdaDados();
                  this.toastService.show('Sucesso', 'Evento deletado com sucesso!')
                },
                err => {
                  console.error(err);
                }
              );
          }
        }
      );
  }

  showToast(template?: TemplateRef<any>) {
    this.toastService.show('TOAST', template || '', { delay: 1000, icon: 'fas fa-question-circle' });
  }


}
