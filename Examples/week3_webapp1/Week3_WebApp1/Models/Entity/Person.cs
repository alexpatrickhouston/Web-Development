using System.ComponentModel.DataAnnotations;

namespace WebApp1_Week3.Models.Entity
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}