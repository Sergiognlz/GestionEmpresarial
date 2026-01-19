import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioPersona } from './formularioPersona';

describe('Formulario', () => {
  let component: FormularioPersona;
  let fixture: ComponentFixture<FormularioPersona>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioPersona]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioPersona);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
