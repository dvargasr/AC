using AutoMapper;
using Chinita.Data;
using Chinita.Data.Entities;
using Chinita.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Controllers.App
{
    public class DogController:Controller
    {
        private ICRepository _repository;
        private IMapper _mapper;
        private IMemoryCache _memoryCache;

        public DogController(ICRepository repository, IMapper mapper, IMemoryCache memoryCache)
        {
            _repository = repository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public IActionResult Dogs()
        {
            List<Dog> dogListCached = null;

            dogListCached = _memoryCache.GetOrCreate("Dogs", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(60);
                entry.Priority = CacheItemPriority.High;
                return _repository.GetDogs().ToList();
            });
            
            return View(_mapper.Map<IEnumerable<Dog>, IEnumerable<DogModel>>(dogListCached));
        }
    }
}
