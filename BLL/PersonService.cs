using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using DAL;

namespace BLL
{
    public class PersonService
    {
        private readonly PulsationsContext context;
        public PersonService(PulsationsContext pulsationsContext)
        {
            context = pulsationsContext;
        }
        public ServiceResponse Save(Person person)
        {
            try
            {
                var personSearch = context.Persons.Find(person.Identification);
                if(personSearch != null) 
                {
                    return  new ServiceResponse("La persona ya se encuentra registrada..!");
                }
        
                person.CalculatePulsation();
                context.Persons.Add(person);
                context.SaveChanges();
                return new ServiceResponse(person);
            }
            catch (Exception e)
            {
                return new ServiceResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public ConsultPersonResponse GetList()
        {
            try
            {
                IList<Person> persons = context.Persons.ToList();
                return new ConsultPersonResponse(persons);
            }
            catch (Exception e)
            {
                return new ConsultPersonResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public ServiceResponse Delete(string identification)
        {
            try
            {
                
                var personSearch = context.Persons.Find(identification);
                if (personSearch != null)
                {
                    context.Persons.Remove(personSearch);
                    context.SaveChanges();
                }
                return new ServiceResponse(personSearch);
            }
            catch (Exception e)
            {

                return new ServiceResponse($"Error de la Aplicación: {e.Message}");
            }
        }
        public ServiceResponse Modidy(Person newPerson)
        {
            try
            {
                var oldPerson = context.Persons.Find(newPerson.Identification);
                if(oldPerson != null)
                {
                    oldPerson.Identification = newPerson.Identification;
                    oldPerson.Name = newPerson.Name;
                    oldPerson.Age = newPerson.Age;
                    oldPerson.Sex = newPerson.Sex;
                    oldPerson.CalculatePulsation();
                    context.Persons.Update(oldPerson);
                    context.SaveChanges();
                }
                
                return new ServiceResponse(newPerson);
            }
            catch (Exception e)
            {

                return new ServiceResponse($"Error de la Aplicación: {e.Message}");
            }
        }
        public ServiceResponse SearchById(string identification)
        {
            try
            {
                Person person = context.Persons.Find(identification);
                return new ServiceResponse(person);
            }
            catch (Exception e)
            {
                
                return new ServiceResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public FiltersResponse Total()
        {
            try
            {
                int total = context.Persons.Count();
                
                return new FiltersResponse(total);
            }
            catch (Exception e)
            {
                return new FiltersResponse($"Error de la Aplicacion: {e.Message}");
            }           
        }
        public FiltersResponse TotalType(string sex)
        {
            try
            {
                int total = context.Persons.Count(p => p.Sex == sex);
               
                return new FiltersResponse(total);
            }
            catch (Exception e)
            {
                return new FiltersResponse($"Error de la Aplicacion: {e.Message}");
            }           
        }
       
    }

    public class ServiceResponse
    {
        public ServiceResponse(Person person)
        {
            Error = false;
            Person = person;
        }

        public ServiceResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public Person Person { get; set; }
    }
    
    

    public class ConsultPersonResponse
    {
        public ConsultPersonResponse(IList<Person> persons)
        {
            Error =  false;
            Persons = persons;
        }

        public ConsultPersonResponse(string message)
        {
            Error = true;
            Message = message;
            
        }
        public bool Error { get; set; }
        public string Message { get; set; }
        public IList<Person> Persons { get; set; }
    }
  
    public class FiltersResponse
    {
        public FiltersResponse(int total)
        {
            Error = false;
            GetTotal = total;
        }

        public FiltersResponse(string message)
        {
            Error = true;
            Message = message;
        }
        public bool Error { get; set; }
        public string Message { get; set; }
        public int GetTotal { get; set; }
    }
}