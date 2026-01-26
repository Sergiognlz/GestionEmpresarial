import { Routes } from '@angular/router';
import { FormularioPersona } from './components/formulario-persona/formulario-persona';
import { ListadoPersonas } from './components/listado-personas/listado-personas';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';

export const routes: Routes = [   // tabla se puede cargar tambien con /tabla
  { path: 'formulario', component: FormularioPersona }, // formulario se carga debajo
  { path: 'listado', component: ListadoPersonas }       // listado en otra ventana
];
