﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fundgrid.MVC.Models
{
    public class GridModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public List<GridItemModel> GridItems { get; set; }
    }
}