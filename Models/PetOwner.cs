using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pet_hotel
// namesspace for pet owner class
{

    public class PetOwner
    // model for pet owners 
    // id, name, emailAddress, petCount are properties of the class
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string emailAddress { get; set; }

        public int petCount { get; set; }


    }
}
