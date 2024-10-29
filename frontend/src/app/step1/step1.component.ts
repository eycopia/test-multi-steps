import { Component } from '@angular/core';
import { Step1Service, Step1DTO } from './step1.service';

@Component({
  selector: 'app-step1',
  templateUrl: './step1.component.html',
  styleUrls: ['./step1.component.css']
})
export class Step1Component {
  formData: Step1DTO = {
    aplicacion: '',
    tipoAfiliacion: '',
    nombre: '',
    rubro: ''
  };

  constructor(private step1Service: Step1Service) {}

  onSubmit() {
    this.step1Service.submitForm(this.formData).subscribe(response => {
      console.log('Respuesta del servidor:', response);
    });
  }
}
