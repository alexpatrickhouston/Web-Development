using System;
using System.ComponentModel.DataAnnotations;

namespace Week4_WebApp1.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}