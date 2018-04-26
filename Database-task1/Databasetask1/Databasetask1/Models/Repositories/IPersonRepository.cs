using System;
using System.Collections.Generic;
using System.Text;

namespace Databasetask1.Models.Repositories
{
    interface IPersonRepository
    {
        /// <summary>
        /// Tänne kuvataan metodit, joita PersonRepositorin tulee toteuttaa
        /// Paluuarvo ja MetodinNimi(mahdolliset parametrit)
        /// </summary>
        ///     

        List<Person> Get();
        Person GetPersonById(int id);
        void Create(Person person);
        void Update(int id, Person person);
        void Delete(int id);


    }
}
