import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PeopleListUseCase } from '../../domain/useCases/PeopleListUseCase';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('ListadoPersonasAngClean');

  // ✅ Inyección usando inject()
  private peopleListUseCase = inject(PeopleListUseCase);

  constructor() {
    this.loadPeople();
  }

  private async loadPeople() {
    const people = await this.peopleListUseCase.execute();
    console.log('Listado de personas:', people);
  }
}
