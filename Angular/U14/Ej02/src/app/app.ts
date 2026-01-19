import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { FormularioPersona } from './components/formularioPersona/formularioPersona';
import { Boton } from './components/boton/boton';
import { ListadoPersonas } from './components/listado-personas/listado-personas';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TablaPersonas, FormularioPersona, Boton, ListadoPersonas],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('holaMundoAngular');
}

