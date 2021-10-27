import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoComponent } from './src/evento/evento.component';
import { PartidaComponent } from './src/partida/partida.component';

const routes: Routes = [
  {   
    path:"evento",
    component:  EventoComponent
  },

  {   
    path:"partida",
    component:  PartidaComponent
  },

  {
    path:"",
    redirectTo:"evento",
    pathMatch: "full"
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
