import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';
import { ModalEditarComponent } from './modal/editar/editar.component';

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
  registerForm: FormGroup = new FormGroup({});

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
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.validation();
    this.carregdaDados();
  }

  filtrarEventos(filtrarPor: string): any[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  carregdaDados(): void {
    this.service.getEvento()
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

  validation(): void {
    this.registerForm = this.fb.group({
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      tema: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      imagemUrl: ['', Validators.required],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    })
  }

  openModal(): void {
    this.modal.show(ModalEditarComponent, {})
      .onHide?.subscribe(
        (res) => {
          alert('fechou' + JSON.stringify(res));
        }
      );
  }

  // Controls 
  get _f() {
    return this.registerForm.controls;
  }

}
