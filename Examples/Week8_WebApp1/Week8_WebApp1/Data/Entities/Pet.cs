using System;
using System.ComponentModel.DataAnnotations;
using Week8_WebApp1.Models;

namespace Week8_WebApp1.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}