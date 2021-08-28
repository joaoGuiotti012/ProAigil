import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: any = [];
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

  eventosFiltrados: any = [];

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getEventos(): void {
    this.http.get(`${environment.API}/Evento`)
      .subscribe(
        (res) => {
          this.eventos = res;
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
