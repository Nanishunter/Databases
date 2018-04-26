using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Databasetask1.Models.Repositories;


namespace Databasetask1
    
{
    class PersonRepository : IPersonRepository
    {
        private readonly LocaldbContext _context = new LocaldbContext();

        /// <summary>
        /// Create = Insert Person to database
        /// </summary>
        /// <param name="person"></param>
        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get = SELECT * FROM Person
        /// </summary>
        /// <returns>List of all Persons</returns>
        public List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
            return persons;
        }

        /// <summary>
        /// GetPersonById = SELECT * FROM Person WHERE Id = @parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One record</returns>
        public Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);
            return person;
        }


        /// <summary>
        /// Update = UPDATE Person WHERE Id=@parameter
        /// all attributes will update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        public void Update(int id, Person person)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                updatePerson.Name = person.Name;
                updatePerson.Age = person.Age;
                _context.Person.Update(updatePerson);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete = DELETE * FROM Person WHERE Id=@parameter
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.Id == id);
            if (delPerson != null)
                _context.Person.Remove(delPerson);
            _context.SaveChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPersonPhone()
        {
            List<Person> persons = _context.Person
                .Include(p => p.Phone)
                .ToListAsync().Result;
            return persons;
        }

        public Person GetPersonByIdAndPhones(int id)
        {
            var person = _context.Person
                .Include(p => p.Phone)
                .Single(p => p.Id == id);

            return person;
        }
    }
}