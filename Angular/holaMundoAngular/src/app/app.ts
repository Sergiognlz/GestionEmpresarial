import { Component, NgModule, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { FormularioPersona } from './components/formularioPersona/formularioPersona';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TablaPersonas, FormularioPersona],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('holaMundoAngular');
}

