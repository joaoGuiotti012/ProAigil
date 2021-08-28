import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: Evento[] = [];
  imagemAltura = 50;
  imagemMargem = 2;
  mostrarImagem = false;

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
    private service: EventoService
  ) { }

  ngOnInit(): void {
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
}
