using System;
using System.ComponentModel.DataAnnotations;

namespace Week4_WebApp1.Models.View
{
    public class PetViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }

        public int UserId { get; set; }
    }
}