﻿using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackingApp.Controllers
{
    public class ExercisesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete() 
        {
            return View();
        }
    }
}
