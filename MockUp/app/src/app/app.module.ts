import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventoComponent } from './src/evento/evento.component';

import {MatCardModule} from '@angular/material/card';

import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import {MatRadioModule} from '@angular/material/radio';
import { PartidaComponent } from './src/partida/partida.component';

import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    EventoComponent,
    PartidaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatCardModule,
    ReactiveFormsModule,
    MatRadioModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }

