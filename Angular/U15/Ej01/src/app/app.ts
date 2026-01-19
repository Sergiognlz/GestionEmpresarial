import { Component } from '@angular/core';
import { RouterOutlet, provideRouter } from '@angular/router';
import { bootstrapApplication } from '@angular/platform-browser';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { routes } from './app.routes';
import { ListadoPersonas } from './components/listado-personas/listado-personas';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TablaPersonas, RouterOutlet],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

  abrirListado() {
    // Abrimos una nueva ventana
    const ventana = window.open('', '_blank', 'width=600,height=400');
    if (!ventana) return;

    // Creamos un documento mínimo para Angular
    ventana.document.write(`
      <!DOCTYPE html>
      <html lang="es">
        <head>
          <title>Listado de Personas</title>
          <base href="/"> <!-- necesario para rutas -->
        </head>
        <body>
          <app-listado-personas></app-listado-personas>
        </body>
      </html>
    `);
    ventana.document.close();

    // Bootstrap del componente ListadoPersonas en la nueva ventana
    bootstrapApplication(ListadoPersonas, {
      providers: [provideRouter(routes)]
    });
  }

}
