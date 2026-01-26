import { Component } from '@angular/core';
import { RouterLink, RouterOutlet, provideRouter } from '@angular/router';

import { TablaPersonas } from './components/tabla-personas/tabla-personas';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TablaPersonas, RouterLink, RouterOutlet],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

  abrirListado() {
  window.open('/listado', '_blank', 'width=900,height=600');
}

}
