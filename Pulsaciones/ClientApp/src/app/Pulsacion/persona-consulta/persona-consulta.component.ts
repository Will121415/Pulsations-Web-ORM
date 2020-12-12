import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/person';
import { PersonaService } from 'src/app/services/persona.service';
import { SignalRService } from 'src/app/services/signal-r.service';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {

  persons: Person[];
  person: Person;
  searchText: string;
  constructor(private personaService: PersonaService, private signalService: SignalRService) { }

  ngOnInit() {
    this.person = new Person();
    this.consult();
    this.signalR();
  }

  consult() {
    this.personaService.get().subscribe(result => { this.persons = result; });
  }
  signalR() {
    this.signalService.signalReceived.subscribe((person: Person) => {
      this.persons.push(person);
    });
  }

  delete(person: Person) {
    this.personaService.delete(person).subscribe(p => {
      if (p.identification != null) {
        alert('Persona eliminada Exitosamente..!');
        this.person = p;
        this.consult();
      } else {
        alert('la persona con identificacion ' + p.identification + 'no se encuentra registrada..!');
        this.person =  new Person();
      }
    });
  }

  loadData(person: Person) {
    this.person = person;
  }
  modify() {
    this.personaService.modify(this.person).subscribe(p => {
      if (p != null) {
        alert('Datos actualizados Exitosamente...!');
        this.person = p;
        this.consult();
      } else {
        alert('al parecer hubo un error, verifique que la persona si exista..!');
        this.person = new Person();
      }
    });
  }
}
