import { Routes } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { ListadoPersonas } from './components/listado-personas/listado-personas';
import { FormularioPersona } from './components/formularioPersona/formularioPersona';

export const routes: Routes = [
  { path: '', component: TablaPersonas },           // ruta inicial
  { path: 'tabla', component: TablaPersonas },
  { path: 'lista', component: ListadoPersonas },
  { path: 'formulario', component: FormularioPersona }
];
