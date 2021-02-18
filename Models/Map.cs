﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PB_JAW.Models
{
    public class Map
    {

        // building attribute
        [Required(ErrorMessage = "Please select a building.")]
        public string Building { get; set; }

        // roomnumber attribute
        [Required(ErrorMessage = "Please select a room number.")]
        public string RoomNumber { get; set; }
    
        //Skeleton for TemplateMapMode() method in Map Model Component
        public void TemplateMapModel(){
        
        }
    }
}