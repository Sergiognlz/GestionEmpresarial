import { Routes } from '@angular/router';
import { FormularioPersona } from './components/formulario-persona/formulario-persona';
import { ListadoPersonas } from './components/listado-personas/listado-personas';

export const routes: Routes = [
  { path: 'formulario', component: FormularioPersona }, // formulario se carga debajo
  { path: 'listado', component: ListadoPersonas }       // listado en otra ventana
];
