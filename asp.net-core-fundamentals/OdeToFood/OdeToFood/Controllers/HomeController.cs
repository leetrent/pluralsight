﻿using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            //var model = new Restaurant
            //{ 
            //    Id = 1, 
            //    Name = "Linda's Vegan Kitchen"
            //};

            //var model = _restaurantData.GetAll();

            var viewModel = new HomeIndexViewModel();
            viewModel.Restaurants = _restaurantData.GetAll();
            viewModel.CurrentMessage = _greeter.getMessageOfTheDay();

            return View(viewModel);

            //return new ObjectResult(model);
            //return Content("Hello from HomeController.Index(), returning IActionResult and extending base Controller");
        }
    }
}