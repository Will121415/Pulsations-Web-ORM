import { Pipe, PipeTransform } from '@angular/core';
import { Person } from '../models/person';

@Pipe({
  name: 'filterPerson'
})
export class FilterPersonPipe implements PipeTransform {

  transform(persons: Person[], searchText: string): any {
    if(searchText == null )return persons;
    return persons.filter(p => p.name.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 
    || p.identification.indexOf(searchText) !== -1);
  }

}
