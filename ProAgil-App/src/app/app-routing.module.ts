import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { HomeComponent } from './componentes/home/home.component';
import { PalestrantesComponent } from './componentes/palestrantes/palestrantes.component';

const routes: Routes = [
  {
    path: 'inicio',
    component: HomeComponent
  },
  {
    path: 'evento',
    loadChildren: () => import('./componentes/eventos/eventos.module').then(m => m.EventosModule)
  },
  {
    path: 'palestrante',
    component: PalestrantesComponent
  },
  {
    path: 'contato',
    component: ContatosComponent
  },
  {
    path: 'sobre',
    component: ContatosComponent
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
