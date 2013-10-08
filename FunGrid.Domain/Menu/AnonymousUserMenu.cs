using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class AnonymousUserMenu:UserMenu
    {
        public AnonymousUserMenu()
        {
            NavbarLeft.Add(
                new Menu
                {
                    Id = 7,
                    Text = "Donate",
                    HRef = "/Project/Donate",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>()
                });

            Sidebar.Insert(1,
                new Menu
                {
                    Id = 7,
                    Text = "Donate",
                    HRef = "/Project/Donate",
                    Role = "",
                    DataToggle = "",
                    DropDown = new List<Menu>(),
                    IsHeader = false
                });
        }
    }
}
