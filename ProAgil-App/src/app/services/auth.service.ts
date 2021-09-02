import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, map } from 'rxjs/operators';

const BASE_URL = `${environment.API}/user`;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private notLogged$ = new BehaviorSubject<Boolean>(false);

  private jwtHelper = new JwtHelperService();
  private decodeToken: any;

  get notLogged(): Observable<any> {
    return this.notLogged$.asObservable();
  }

  constructor(private http: HttpClient) {
    this.notLogged$.next(this.isTokenExpired());
  }

  login(user: any): Observable<any> {
    return this.http
      .post(`${BASE_URL}/login`, user).pipe(
        map(({ token, user }: any) => {
          if (token) {
            localStorage.setItem('token', token);
            this.decodeToken = this.jwtHelper.decodeToken(token);
            this.notLogged$.next(false);
          }
        })
      );
  }

  logout() {
    this.notLogged$.next(true);
    let theme = localStorage.getItem('theme');
    localStorage.clear();
    localStorage.setItem('theme', theme || 'theme-light');
  }

  register(user: any) {
    return this.http.post(`${BASE_URL}/register`, user);
  }

  isTokenExpired(): Boolean {
    const token: string = localStorage.getItem('token') || '';
    return this.jwtHelper.isTokenExpired(token);
  }

}
