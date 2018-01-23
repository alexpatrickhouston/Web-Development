using System.Collections.Generic;
using WebApp1_Week3.Models.Entity;

namespace WebApp1_Week3.Database
{
    public static class InMemoryDatabase
    {
        public static List<Person> Persons;

        static InMemoryDatabase()
        {
            Persons = new List<Person>();
        }
    }
}