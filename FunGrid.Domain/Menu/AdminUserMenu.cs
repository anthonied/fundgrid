using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class AdminUserMenu:UserMenu
    {
        public AdminUserMenu()
        {
            NavbarLeft.Add(            
                new Menu{
                    Id = 8,
                    Text = "Mange Projects",
                    HRef = "/Project/Index",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                });


            Sidebar.Insert(1,
                new Menu
                {
                    Id = 8,
                    Text = "Mange Projects",
                    HRef = "/Project/Index",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = false
                });

        }
    }
}
