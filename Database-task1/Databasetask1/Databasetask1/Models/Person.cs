using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Databasetask1.Models.Repositories
{
    public partial class Person
    {
       
        {
            public Person()
            {
                Phone = new HashSet<Phone>();
            }

            public Person(string name, short? age)
            {
                Name = name;
                Age = age;
                Phone = new HashSet<Phone>();
            }

            public Person(string name, short? age, ICollection<Phone> phone)
            {
                Name = name;
                Age = age;
                Phone = phone;
            }

            public long Id { get; set; }
            [Column(TypeName = "varchar(50)")]
            public string Name { get; set; }
            public short? Age { get; set; }

            [InverseProperty("Person")]
            public ICollection<Phone> Phone { get; set; }

            public override string ToString()
            {
                return $"{Name} {Age}";
            }
            public string ShowData()
            {
                return $"{Id}, {Name}, {Age}";
            }
        }
    }