using HRTraining.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining_asp.Controllers
{
    public abstract class EntityControllerBase<T> : Controller
        where T : EntityBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
