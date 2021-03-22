﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PB_JAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PB_JAW.Controllers
{
    public class MapController : Controller
    {
        private IWebHostEnvironment host;

        public MapController(IWebHostEnvironment host)
        {
            this.host = host;
        }

        // using input fields create a new map template
        [HttpGet]
        public ViewResult MapBuilder(int? numMaps)
        {
            TemplateModelMap templateModel = new TemplateModelMap();

            // create first map
            MapModel start = new MapModel();
            templateModel.AddMap(start);
            numMaps--;


            MapModel destination = new MapModel();
            templateModel.AddMap(destination);
            numMaps--;


            return View("MapBuilder", templateModel);
        }

        // create/save map and return new view for the user to see
        //TAKES PLACE OF CreateModel() method on Map Controller Component
        [HttpPost]
        public async Task<ViewResult> SaveMapAsync(TemplateModelMap templateModel)
        {
            if(templateModel.Maps[0].Building.Contains("-2") ||  templateModel.Maps[1].Building.Contains("-2"))
            {
                ModelState.AddModelError("", "Please select a building");
            }

            //templateModel.Maps[0].CheckStart(templateModel.Maps[0].Building);
            
            if (ModelState.IsValid)
            {
                // code to generate template map
                MapUtilities util = new MapUtilities(host);
                try
                {
                    Console.WriteLine(templateModel.ButtonClicked);
                    List<string> fileNames = new List<string>();
                    fileNames = await util.CreateMap(templateModel.Maps);

                    TempData["Map0"] = fileNames[0];
                    TempData["Map1"] = fileNames[1];
                    // TempData["Instructions"] = util.Directions(templateModel.Maps);
                }
                catch
                {
                    Console.WriteLine("something went wrong");
                }
                return View("Result", templateModel);
            }
            else
            {
                ModelState.AddModelError("", "");
                return View("MapBuilder", templateModel);
            }
        }

    }
}
