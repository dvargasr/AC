using Chinita.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Data
{
    public class CSeeder
    {
        private readonly CContext _context;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CSeeder(CContext context, IWebHostEnvironment hosting, UserManager<StoreUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("dvargasr@gmail.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    Email = "dvargasr@gmail.com",
                    UserName = "dvargasr@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Password!1");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Couldn't create new user in seeder");
                }
            }

            IdentityRole role = await _roleManager.FindByNameAsync("Administrators");

            if (role == null)
            {
                role = new IdentityRole()
                {
                    Name = "Administrators"
                };

                var roleResult = await _roleManager.CreateAsync(role);

                if (roleResult != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Couldn't create new role in seeder");
                }
            }

            bool assignmentTest = await _userManager.IsInRoleAsync(user, "Administrators");
            
            if (!assignmentTest)
            {
                var assignmentResult = await _userManager.AddToRoleAsync(user, "Administrators");

                if (assignmentResult != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Couldn't assign Administrators role to user in seeder");
                }
            }

            if (!_context.Dogs.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/Dogs.json");
                var jsonDogs = File.ReadAllText(filepath);
                var dogs = JsonConvert.DeserializeObject<IEnumerable<Dog>>(jsonDogs);
                _context.Dogs.AddRange(dogs);

                filepath = Path.Combine(_hosting.ContentRootPath, "Data/AdoptionStories.json");
                var jsonAdoptions = File.ReadAllText(filepath);
                var adoptions = JsonConvert.DeserializeObject<IEnumerable<AdoptionStory>>(jsonAdoptions);
                _context.AdoptionStories.AddRange(adoptions);

                _context.SaveChanges();
            }
        }
    }
}
