﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public int ScreenId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
