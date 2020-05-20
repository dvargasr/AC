using AutoMapper;
using Chinita.Data;
using Chinita.Data.Entities;
using Chinita.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Controllers.App
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private readonly UserManager<StoreUser> _userManager;
        private IMapper _mapper;
        private ICRepository _repository;

        public AdminController(UserManager<StoreUser> userManager, IMapper mapper, ICRepository repository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _repository = repository;
        }

        public IActionResult UserManagement()
        {
            var users = _userManager.Users;

            return View(users);
        }
    }
}
