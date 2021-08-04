using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDC_API_02.Models.Dogs
{
    public class Breed
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string BreedName { get; set; }

        public string Section { get; set; }

        public string Country { get; set; }

        public Breed(string breedName, string section, string country)
        {
            BreedName = breedName;
            Section = section;
            Country = country;
        }
        public Breed()
        {

        }
    }
}