using Chinita.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Data
{
    public class CRepository : ICRepository
    {
        private readonly CContext _context;
        private readonly ILogger<CContext> _logger;
        public CRepository(CContext context, ILogger<CContext> logger)
        {
            _logger = logger;
            _context = context;
        }
        public void AddAdoptionStory(AdoptionStory adoptionStory)
        {
            try
            {
                _context.AdoptionStories.Add(adoptionStory);
            }
            catch 
            {
                throw;
            }
        }

        public void AddDog(Dog dog)
        {
            try 
            {
                _context.Dogs.Add(dog);
            }
            catch 
            {
                throw;
            }
        }

        public IEnumerable<AdoptionStory> GetAdoptionStories()
        {
            try
            {
                return _context.AdoptionStories.ToList();
            }
            catch 
            {
                throw;
            }
        }

        public Dog GetDog(int dogId)
        {
            try 
            {
                return _context.Dogs.FirstOrDefault(d => d.Id == dogId);
            }
            catch 
            {
                throw;
            }
        }

        public IEnumerable<Dog> GetDogs()
        {
            try 
            {
                return _context.Dogs;
            }
            catch 
            {
                throw;
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDog(Dog dog)
        {
            try
            {
                _context.Dogs.Update(dog);
                _context.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }
    }
}
