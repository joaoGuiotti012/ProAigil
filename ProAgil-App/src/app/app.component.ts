import { DOCUMENT } from '@angular/common';
import { Component, HostBinding, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthService } from './services/auth.service';

const DARK = 'theme-dark';
const LIGTH = 'theme-light';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  notLogged: Observable<any>;

  title = 'ProAgil-App';

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private auth: AuthService,
    private router: Router,
  ) {
    let isDark = false;
    if (localStorage.getItem('theme')) {
      isDark = localStorage.getItem('theme') === DARK;
    }
    this.trocarTema(isDark);
    this.notLogged = auth.notLogged;
  }

  trocarTema(isDark: boolean) {
    this.document.body.classList.remove(!isDark ? DARK : LIGTH);
    this.document.body.classList.add(isDark ? DARK : LIGTH);
    localStorage.setItem('theme', isDark ? DARK : LIGTH);
  }

}
