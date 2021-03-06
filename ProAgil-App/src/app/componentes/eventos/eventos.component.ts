import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ToastService } from '../_infra/toast/toast.service';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';
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

  itensPorPagina = 10;
  paginaAtual = 1;
  totalRegistros = 0;
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
    this.filtroLista ? this.eventosFiltrados = this.filtrarEventos(value) : this.eventosFiltrados = this.aplicarPaginacao();
  }

  eventosFiltrados: Evento[] = [];

  constructor(
    private service: EventoService,
    private modal: BsModalService,
    private toastService: ToastService,
    private toast: ToastrService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let evento: Evento = this.route.snapshot.data['evento'];

    if (evento)
      this.openModalEditar(evento);

    this.carregdaDados();
  }

  onChangeFilter(value: any) {
    alert(JSON.stringify(value));
  }

  filtrarEventos(filtrarPor: string): any[] {
    let contains: Function = (value: string) => value.toLocaleLowerCase()
      .indexOf(filtrarPor.toLocaleLowerCase()) !== -1;
    this.totalRegistros = this.eventos.length;
    return this.eventos.filter(
      (e: Evento) => contains(e.tema) || contains(e.local)
    );
  }

  carregdaDados(): void {
    this.service.get()
      .subscribe(
        (_eventos: Evento[]) => {
          this.totalRegistros = _eventos.length;
          this.eventos = _eventos;
          this.eventosFiltrados = this.aplicarPaginacao(_eventos);
        },
        err => {
          this.toast.error('Erro ao tentar carregar os eventos', 'ERRO');
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
      evento: Object.assign({}, evento)
    }
    this.modal.show(ModalEditarComponent, { class: 'modal-lg', ignoreBackdropClick: true, initialState })
      .content?.onClose.subscribe(
        (res: any) => {
          if (res) {
            let eventoToUpdate: Evento = Object.assign({}, evento, this.uploadImagem(res));
            evento.imagemUrl = eventoToUpdate.imagemUrl;
            this.service.update(eventoToUpdate)
              .subscribe(
                (res) => {
                  this.carregdaDados();
                  this.toast.success(`O evento ${evento.tema}, foi alterado!`, 'Sucesso')
                },
                err => {
                  this.toast.success('ERRO', JSON.stringify(err))
                }
              )
          }
        }
      );
  }

  uploadImagem(res: any): Evento {
    let fileName = `${Date.now().toString().trim()}.${res.file[0].type.split("/")[1]}`;
    this.service.upload(res.file, fileName).subscribe();
    res.evento.imagemUrl = fileName;
    return res.evento
  }

  openModalNovo() {
    this.modal.show(ModalNovoComponent, { class: 'modal-lg', ignoreBackdropClick: true })
      .content?.onClose.subscribe(
        (res: any) => {
          if (res) {
            let newEvento: Evento = this.uploadImagem(res);
            this.service.create(newEvento)
              .subscribe(
                (novoEvento: Evento) => {
                  console.log(novoEvento);
                  this.carregdaDados();
                  this.toast.success('Novo Evento foi inserido na agenda!', 'Sucesso');
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
                  this.toast.success('Evento deletado com sucesso!', 'Sucesso')
                },
                err => {
                  console.error(err);
                }
              );
          }
        }
      );
  }

  handlePagesChanges(pag: any): void {
    this.paginaAtual = pag.page;
    let paginasDe = (pag.page * pag.itemsPerPage) - pag.itemsPerPage;
    let paginasAte = pag.page * pag.itemsPerPage;
    this.eventosFiltrados = this.eventos.filter((x, i) => ((i + 1) > paginasDe && (i + 1) <= paginasAte));
  }

  handleNumPage($evento: any) {
    // alert(JSON.stringify($evento));
  }

  showToast(template?: TemplateRef<any>) {
    this.toastService.show('TOAST', template || '', { delay: 1000, icon: 'fas fa-question-circle' });
  }

  aplicarPaginacao(_eventos?: Evento[]): Evento[] {
    let paginaAte = (this.paginaAtual * this.itensPorPagina);
    let paginaDe = paginaAte - this.itensPorPagina;
    if (!_eventos)
      _eventos = this.eventos;
    this.totalRegistros = _eventos.length;
    return _eventos.filter((x, i) => (i + 1) > paginaDe && (i + 1) <= paginaAte);
  }


  trackById(index: number, item: any) {
    return item.id;
  }
}
