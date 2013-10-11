using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FunGrid.Domain;

namespace Fundgrid.MVC.Models
{
	public class GridModel
	{
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<Grid> Grids { get; set; }
	}
}