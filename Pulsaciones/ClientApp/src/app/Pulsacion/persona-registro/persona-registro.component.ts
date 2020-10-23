import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/person';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  person: Person;

  constructor(private personaService: PersonaService) { }

  ngOnInit() {
    this.person =  new Person;
  }


  add(){
    this.personaService.post(this.person).subscribe(p => {
      if (p != null) {
        alert('Persona creada!');
        this.person = p;
      }
    });
  }

}
