using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.PetTable.Include(pet => pet.petOwner);
        }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }

        [HttpGet("{id}")]

        public ActionResult<Pet> GetPetByID(int id)
        {
            Pet pet = _context.PetTable.SingleOrDefault(pet => pet.id ==id);
            if (pet == null)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpPost]
        public IActionResult PostPet(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PostPet), new {pet.id}, pet);
        }
        // public Pet PostPet(Pet pet)
        // {
        //     _context.Add(pet);
        //     _context.SaveChanges();
        //     return pet;
        // }

        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            Pet pet = _context.PetTable.Find(id);
            _context.Remove(pet);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public Pet PutPet(int id, Pet pet)
        {
            pet.id = id;

            _context.Update(pet);
            _context.SaveChanges();
            return pet;

        }

        [HttpPut("{id}/checkin")]
        public Pet PutPetCheckin(int id, Pet pet)
        {
            pet.id = id;

            _context.Update(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}/checkout")]
                public Pet PutPetCheckout(int id, Pet pet)
        {
            pet.id = id;

            _context.Update(pet);
            _context.SaveChanges();
            return pet;
        }
        
    }
}
