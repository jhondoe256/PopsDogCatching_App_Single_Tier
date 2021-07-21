using PopsDogCatching_API.Models.Dogs.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PopsDogCatching_API.Models.Dogs
{
    public class Dog
    {
        [Key]
        public int ID { get; set; }
       
        [Required]
        public string Name { get; set; }
      
        public int Age 
        {
            get 
            {
                if (HasChipIdentification || HasCollarIdentification)
                {
                    var age= DateTime.Now.Year - DateOfBirth.Year;
                    return age;
                }
                else
                {
                    return 0;
                }
            } 
        }
       
        public DateTimeOffset DateOfBirth { get; set; }

        
        public DateTimeOffset CaptureDate { get; set; }
        
        [ForeignKey(nameof(Breed))]
        public int? BreedID { get; set; }
        public virtual Breed Breed { get; set; }
        
        [Required]
        public bool HasCollarIdentification { get; set; }
       
        [Required]
        public bool HasChipIdentification{ get; set; }
      
        [Required]
        public bool WasFoundInjured { get; set; }
       
        [Required]
        public DogTempermentType DogTemperment { get; set; }
       
        [Required]
        public DogInjurySeverityType DogInjurySeverity { get; set; }

    }
}