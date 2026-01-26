import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-boton',
  standalone: true,
  imports: [FormsModule],
  templateUrl:'./boton.html',
  styleUrl: './boton.css'
})

export class Boton {
  saludar() {
    alert('¡Hola! 👋');
  }
}
