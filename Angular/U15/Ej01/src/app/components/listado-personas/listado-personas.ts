import { Component } from '@angular/core';

@Component({
  selector: 'app-listado-personas',
  standalone: true,
  templateUrl: './listado-personas.html',
  styleUrls: ['./listado-personas.css'],
})
export class ListadoPersonas {
  volver() {
    window.close(); // cierra la ventana nueva
  }
}
