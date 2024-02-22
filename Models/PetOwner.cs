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
        [EmailAddress]
        // https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.emailaddressattribute?view=net-8.0

        public string emailAddress { get; set; }

        // not mapped is 
        [NotMapped]
        public int petCount { get; set; }


    }
}
