import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: any;

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.getEventos();
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
}
