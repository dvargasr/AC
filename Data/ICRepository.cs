using Chinita.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Data
{
    public interface ICRepository
    {
        public IEnumerable<Dog> GetDogs();
        public IEnumerable<AdoptionStory> GetAdoptionStories();
        public void AddDog(Dog dog);
        public void AddAdoptionStory(AdoptionStory adoptionStory);
        public Dog GetDog(int dogId);
        public void UpdateDog(Dog dog);
        public bool Save();
    }
}
