import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/person';
import { Alert} from 'src/app/models/alert';
import { PersonaService } from 'src/app/services/persona.service';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  person: Person;
  formGroup: FormGroup;
  alert: Alert;

  constructor(private personaService: PersonaService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {

    this.alert = new Alert(false, '');
    this.person = new Person();
    this.person.identification = '';
    this.person.name = '';
    this.person.pulsation = 0;
    this.person.sex = 'seleccionar...';

    this.formGroup = this.formBuilder.group({
      identification: [this.person.identification , Validators.required],
      name: [this.person.name, Validators.required],
      age: [this.person.age, Validators.required],
      pulsation: [this.person.pulsation, Validators.required],
      sex: [this.person.sex, this.validSex]

    });
  }

  private validSex(control: AbstractControl) {
    const sex = control.value;
    if (sex !== 'seleccionar...') {return null; }

    return { validSexo: true, messageSexo: 'se debe seleccionar una opcion'};
  }
  get control() {
    return this.formGroup.controls;
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.person = this.formGroup.value;
    this.personaService.post(this.person).subscribe(p => {
      if (p != null) {
        this.alert.message = 'Persona Guardada Exitosamente..!';
        this.alert.save = true;
        this.person = p;
      }
    });
  }

}
