using AutoMapper;
using Chinita.Data;
using Chinita.Data.Entities;
using Chinita.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Controllers.App
{
    public class DogAdminController:Controller
    {
        private IMapper _mapper;
        private ICRepository _repository;

        public DogAdminController(IMapper mapper, ICRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public IActionResult DogManagement()
        {
            return View(_mapper.Map<IEnumerable<Dog>, IEnumerable<DogModel>>(_repository.GetDogs()));
        }

        public IActionResult EditDog(int dogId)
        {
            return View(_mapper.Map<Dog, DogModel>(_repository.GetDog(dogId)));
        }

        [HttpPost]
        public IActionResult EditDog(DogModel dogModel)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateDog(_mapper.Map<DogModel, Dog>(dogModel));
                return RedirectToAction("DogManagement");
            }

            return View(dogModel);
        }
    }
}
