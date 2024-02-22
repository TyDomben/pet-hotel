using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    // This controller will handle all requests to /api/petowners
    // named PetOwnersController to match the controller name in routes
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return _context.PetOwnerTable;
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetOwnerByID(int id)
        {
            PetOwner petOwner = _context.PetOwnerTable.SingleOrDefault(owner => owner.id == id);
            if (petOwner == null)
            {
                return NotFound();
            }
            return petOwner;
        }

        [HttpPost]
        public PetOwner PostOwner(PetOwner petOwner)
        {
            _context.Add(petOwner);
            _context.SaveChanges();
            return petOwner;
        }
        [HttpPut("{id}")]
        // this id is the id of the pet owner we are updating
        public PetOwner PutOwner(int id, PetOwner petOwner)
        {
            petOwner.id = id;
            // refrenced in the PUT method
            _context.Update(petOwner);
            _context.SaveChanges();
            return petOwner;
            // this id is the id of the pet owner we are updating
        }
    }
}