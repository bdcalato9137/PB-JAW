﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PB_JAW.Models
{
    public class MapModel
    {
        [Required(ErrorMessage = "Please select a building.")]
        public string Building { get; set; }

        // roomnumber attribute
        [Required(ErrorMessage = "Please select a room number.")]
        public int RoomNumber { get; set; }

        public void CheckStart(string Building)
        {
            if (Building.Contains("-1"))
            {
                RoomNumber = -1;
            }
        }
    }
}
