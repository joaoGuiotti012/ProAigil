import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { HomeComponent } from './componentes/home/home.component';
import { PalestrantesComponent } from './componentes/palestrantes/palestrantes.component';
import { LoginComponent } from './componentes/user/login/login.component';
import { RegisterComponent } from './componentes/user/register/register.component';
import { UserComponent } from './componentes/user/user.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: 'inicio',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'user',
    component: UserComponent
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'evento',
    loadChildren: () => import('./componentes/eventos/eventos.module').then(m => m.EventosModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'palestrante',
    component: PalestrantesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'contato',
    component: ContatosComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'sobre',
    component: ContatosComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '',
    redirectTo: '/inicio',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: '/evento',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
