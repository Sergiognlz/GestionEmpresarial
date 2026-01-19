import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-formulario-persona',
  standalone: true,
  imports: [FormsModule],
  templateUrl:'./formulariopersona.html',
  styleUrl: './formulariopersona.css'
})
export class FormularioPersona {
  nombre = '';
  apellidos = '';

  guardar() {
    alert(`Nombre: ${this.nombre}\nApellidos: ${this.apellidos}`);
    this.nombre = '';
    this.apellidos = '';
  }
}
